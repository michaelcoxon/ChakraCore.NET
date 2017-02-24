﻿using System;
using ChakraCore.NET.API;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
using ChakraCore.NET.GC;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChakraCore.NET
{
    public class ChakraContext : IDisposable
    {
        private static JavaScriptSourceContext currentSourceContext = JavaScriptSourceContext.FromIntPtr(IntPtr.Zero);

        //private Dictionary<object, List<object>> holder = new Dictionary<object, List<object>>();
        //private static Queue<JavaScriptValue> taskQueue = new Queue<JavaScriptValue>();

        //private Dictionary<Type, object> proxyList = new Dictionary<Type, object>();
        public ProxyMapManager ProxyMapManager { get; private set; } = new ProxyMapManager();

        internal JavaScriptContext jsContext;
        public JSValueConverter ValueConverter { get; set; }

        private AutoResetEvent waitHanlder;

        private CancellationTokenSource promiseTaskCTS = new CancellationTokenSource();
        private BlockingCollection<JavaScriptValue> promiseTaskQueue = new BlockingCollection<JavaScriptValue>();

        public JavaScriptValue JSValue_Undefined;
        public JavaScriptValue JSValue_Null;
        public JavaScriptValue JSValue_True;
        public JavaScriptValue JSValue_False;

        //public GC.StackTraceNode GCStackTrace { get; private set; }

        internal JavaScriptValue GlobalObject
        {
            get
            {
                return With<JavaScriptValue>(() =>
                {
                    JavaScriptValue result;
                    result = JavaScriptValue.GlobalObject;
                    return result;
                }
                );
            }
        }

        public JSValue RootObject { get; private set; }

        private bool isDebug;
        internal ChakraContext(JavaScriptContext jsContext, AutoResetEvent syncHandler)
        {
            jsContext.AddRef();
            this.jsContext = jsContext;
            this.waitHanlder = syncHandler;
        }

        internal void Init(bool enableDebug)
        {
            isDebug = enableDebug;
            With(() =>
            {
                JavaScriptPromiseContinuationCallback promiseContinuationCallback = delegate (JavaScriptValue task, IntPtr callbackState)
                {
                    promiseTaskQueue.Add(task);
                };

                if (Native.JsSetPromiseContinuationCallback(promiseContinuationCallback, IntPtr.Zero) != JavaScriptErrorCode.NoError)
                {
                    throw new InvalidOperationException("failed to setup callback for ES6 Promise");
                }
                StartPromiseTaskLoop(promiseTaskCTS.Token);

                //Native.JsSetObjectBeforeCollectCallback()


                ValueConverter = new JSValueConverter();
                JSValue_Undefined = JavaScriptValue.Undefined;
                JSValue_Null = JavaScriptValue.Null;
                JSValue_True = JavaScriptValue.True;
                JSValue_False = JavaScriptValue.False;

                RootObject = JSValue.CreateRoot(this);

            });
            //JavaScriptContext.Current = jsContext;//TODO: use With()

            //JavaScriptContext.Current = JavaScriptContext.Invalid;

        }

        /// <summary>
        /// Create a proxy for dotnet object for dotnet object instance, makes it accessible in javascript
        /// </summary>
        /// <typeparam name="T">dotnet object type</typeparam>
        /// <param name="source">dotnet object instance</param>
        /// <param name="proxyDelegateHandler">delegate handler,handles all function callback delegate to the dotnet object instance</param>
        /// <returns></returns>
        internal JavaScriptValue CreateProxy<T>(T source, out DelegateHandler proxyDelegateHandler) where T:class
        {
            
            var result = ProxyMapManager.ReigsterMap<T>(source, (p, callback) =>

               {
                   return With<JavaScriptValue>(() =>
                   {
                       return JavaScriptValue.CreateExternalObject(p, callback);
                   }
               );
               }
               ,out DelegateHandler handler
            );
            proxyDelegateHandler = handler;
            return result;
        }

        private void StartPromiseTaskLoop(CancellationToken token)
        {
            Task.Factory.StartNew(
                ()=>
                {
                    System.Diagnostics.Debug.WriteLine("Promise task loop started");
                    while (true)
                    {
                        JavaScriptValue task;
                        try
                        {
                            task = promiseTaskQueue.Take(token);
                            System.Diagnostics.Debug.WriteLine("Promise task taken");
                        }
                        catch(OperationCanceledException)
                        {
                            System.Diagnostics.Debug.WriteLine("Promise task stop");
                            return;
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        With(() =>
                        {
                            task.CallFunction(GlobalObject);
                        });
                        System.Diagnostics.Debug.WriteLine("Promise task complete");
                    }
                }
                ,token
                );
        }
        
        /// <summary>
        /// try switch context to current thread
        /// </summary>
        /// <returns>true if release is required, false if context already running at current thread(no release call required)</returns>
        public bool Enter()
        {
            lock (waitHanlder)//thread safe for status check
            {
                if (IsCurrentContext)
                {
                    return false;//no operation required
                }
            }
            waitHanlder.WaitOne();//wait other call complete
            JavaScriptContext.Current = jsContext;
#if DEBUG
            Debug.WriteLine("context enter"); 
#endif
            return true;
        }

        public bool IsCurrentContext
        {
            get
            {
                return JavaScriptContext.Current == jsContext;
            }
        }

        public void Leave()
        {
            JavaScriptContext.Current = JavaScriptContext.Invalid;
            waitHanlder.Set();
#if DEBUG
            Debug.WriteLine("context leave");
#endif

        }

        public void With(Action a)
        {
            if (Enter())
            {
                
                a();
                Leave();
            }
            else
            {
                a();
            }
        }

        public void TrackValueGC(JavaScriptValue value)
        {
            
        }
        public void With(Action a, JavaScriptValue currentCaller)
        {
            JavaScriptValue prevousCaller = ValueConverter.JSCaller;
            ValueConverter.JSCaller = currentCaller;
            With(a);
            ValueConverter.JSCaller = prevousCaller;
        }

        public T With<T>(Func<T> f)
        {
            if (Enter())
            {
                T tmp = f();
                Leave();
                return tmp;
            }
            else
            {
                return f();
            }
        }

        public T With<T>(Func<T>f,JavaScriptValue currentCaller)
        {
            JavaScriptValue prevousCaller = ValueConverter.JSCaller;
            ValueConverter.JSCaller = currentCaller;
            var result=With<T>(f);
            ValueConverter.JSCaller = prevousCaller;
            return result;
        }


        public string RunScript(string script)
        {
            JavaScriptValue result;
            return With<string>(() =>
            {
                if (isDebug)
                {
                    result = JavaScriptContext.RunScript(script, currentSourceContext++, string.Empty);
                }
                else
                {
                    result = JavaScriptContext.RunScript(script);
                }
                return result.ConvertToString().ToString();
            });
        }


        public JavaScriptValue ParseScript(string script)
        {
            return With<JavaScriptValue>(() =>
            {
                JavaScriptValue result;
                if (isDebug)
                {
                    result = JavaScriptContext.ParseScript(script, currentSourceContext++, string.Empty);
                }
                else
                {
                    result = JavaScriptContext.ParseScript(script);
                }
                return result;
            }
            );
        }






        

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    promiseTaskCTS.Cancel();
                    jsContext.Release();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion


    }
}
