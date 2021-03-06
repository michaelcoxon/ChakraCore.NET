﻿

using System;
using System.Collections.Generic;
using ChakraCore.NET.API;
namespace ChakraCore.NET
{
public static partial class JSValueConverterHelper
{

    private static JavaScriptValue ToJSMethod (IServiceNode node, Action a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 1)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                
                

                a();
                
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action FromJSMethod(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action result = () =>
              {
                         
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      
                      value.CallFunction(caller);
                      
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1> (IServiceNode node, Action<T1> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 2)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
                arguments[1].AddRef();

                a(para1);
                arguments[1].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1> FromJSMethod<T1>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1> result = (T1 para1) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
                      value.CallFunction(caller,p1);
                      p1.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1,T2> (IServiceNode node, Action<T1,T2> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 3)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
T2 para2 = converter.FromJSValue<T2>(arguments[2]);
                arguments[1].AddRef();
arguments[2].AddRef();

                a(para1,para2);
                arguments[1].Release();
arguments[2].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1,T2> FromJSMethod<T1,T2>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1,T2> result = (T1 para1,T2 para2) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);
JavaScriptValue p2 = converter.ToJSValue<T2>(para2);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
p2.AddRef();
                      value.CallFunction(caller,p1,p2);
                      p1.Release();
p2.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1,T2,T3> (IServiceNode node, Action<T1,T2,T3> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 4)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
T2 para2 = converter.FromJSValue<T2>(arguments[2]);
T3 para3 = converter.FromJSValue<T3>(arguments[3]);
                arguments[1].AddRef();
arguments[2].AddRef();
arguments[3].AddRef();

                a(para1,para2,para3);
                arguments[1].Release();
arguments[2].Release();
arguments[3].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1,T2,T3> FromJSMethod<T1,T2,T3>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1,T2,T3> result = (T1 para1,T2 para2,T3 para3) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);
JavaScriptValue p2 = converter.ToJSValue<T2>(para2);
JavaScriptValue p3 = converter.ToJSValue<T3>(para3);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
p2.AddRef();
p3.AddRef();
                      value.CallFunction(caller,p1,p2,p3);
                      p1.Release();
p2.Release();
p3.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1,T2,T3,T4> (IServiceNode node, Action<T1,T2,T3,T4> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 5)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
T2 para2 = converter.FromJSValue<T2>(arguments[2]);
T3 para3 = converter.FromJSValue<T3>(arguments[3]);
T4 para4 = converter.FromJSValue<T4>(arguments[4]);
                arguments[1].AddRef();
arguments[2].AddRef();
arguments[3].AddRef();
arguments[4].AddRef();

                a(para1,para2,para3,para4);
                arguments[1].Release();
arguments[2].Release();
arguments[3].Release();
arguments[4].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1,T2,T3,T4> FromJSMethod<T1,T2,T3,T4>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1,T2,T3,T4> result = (T1 para1,T2 para2,T3 para3,T4 para4) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);
JavaScriptValue p2 = converter.ToJSValue<T2>(para2);
JavaScriptValue p3 = converter.ToJSValue<T3>(para3);
JavaScriptValue p4 = converter.ToJSValue<T4>(para4);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
p2.AddRef();
p3.AddRef();
p4.AddRef();
                      value.CallFunction(caller,p1,p2,p3,p4);
                      p1.Release();
p2.Release();
p3.Release();
p4.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1,T2,T3,T4,T5> (IServiceNode node, Action<T1,T2,T3,T4,T5> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 6)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
T2 para2 = converter.FromJSValue<T2>(arguments[2]);
T3 para3 = converter.FromJSValue<T3>(arguments[3]);
T4 para4 = converter.FromJSValue<T4>(arguments[4]);
T5 para5 = converter.FromJSValue<T5>(arguments[5]);
                arguments[1].AddRef();
arguments[2].AddRef();
arguments[3].AddRef();
arguments[4].AddRef();
arguments[5].AddRef();

                a(para1,para2,para3,para4,para5);
                arguments[1].Release();
arguments[2].Release();
arguments[3].Release();
arguments[4].Release();
arguments[5].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1,T2,T3,T4,T5> FromJSMethod<T1,T2,T3,T4,T5>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1,T2,T3,T4,T5> result = (T1 para1,T2 para2,T3 para3,T4 para4,T5 para5) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);
JavaScriptValue p2 = converter.ToJSValue<T2>(para2);
JavaScriptValue p3 = converter.ToJSValue<T3>(para3);
JavaScriptValue p4 = converter.ToJSValue<T4>(para4);
JavaScriptValue p5 = converter.ToJSValue<T5>(para5);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
p2.AddRef();
p3.AddRef();
p4.AddRef();
p5.AddRef();
                      value.CallFunction(caller,p1,p2,p3,p4,p5);
                      p1.Release();
p2.Release();
p3.Release();
p4.Release();
p5.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1,T2,T3,T4,T5,T6> (IServiceNode node, Action<T1,T2,T3,T4,T5,T6> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 7)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
T2 para2 = converter.FromJSValue<T2>(arguments[2]);
T3 para3 = converter.FromJSValue<T3>(arguments[3]);
T4 para4 = converter.FromJSValue<T4>(arguments[4]);
T5 para5 = converter.FromJSValue<T5>(arguments[5]);
T6 para6 = converter.FromJSValue<T6>(arguments[6]);
                arguments[1].AddRef();
arguments[2].AddRef();
arguments[3].AddRef();
arguments[4].AddRef();
arguments[5].AddRef();
arguments[6].AddRef();

                a(para1,para2,para3,para4,para5,para6);
                arguments[1].Release();
arguments[2].Release();
arguments[3].Release();
arguments[4].Release();
arguments[5].Release();
arguments[6].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1,T2,T3,T4,T5,T6> FromJSMethod<T1,T2,T3,T4,T5,T6>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1,T2,T3,T4,T5,T6> result = (T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);
JavaScriptValue p2 = converter.ToJSValue<T2>(para2);
JavaScriptValue p3 = converter.ToJSValue<T3>(para3);
JavaScriptValue p4 = converter.ToJSValue<T4>(para4);
JavaScriptValue p5 = converter.ToJSValue<T5>(para5);
JavaScriptValue p6 = converter.ToJSValue<T6>(para6);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
p2.AddRef();
p3.AddRef();
p4.AddRef();
p5.AddRef();
p6.AddRef();
                      value.CallFunction(caller,p1,p2,p3,p4,p5,p6);
                      p1.Release();
p2.Release();
p3.Release();
p4.Release();
p5.Release();
p6.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    private static JavaScriptValue ToJSMethod<T1,T2,T3,T4,T5,T6,T7> (IServiceNode node, Action<T1,T2,T3,T4,T5,T6,T7> a)
        {
            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != 8)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                T1 para1 = converter.FromJSValue<T1>(arguments[1]);
T2 para2 = converter.FromJSValue<T2>(arguments[2]);
T3 para3 = converter.FromJSValue<T3>(arguments[3]);
T4 para4 = converter.FromJSValue<T4>(arguments[4]);
T5 para5 = converter.FromJSValue<T5>(arguments[5]);
T6 para6 = converter.FromJSValue<T6>(arguments[6]);
T7 para7 = converter.FromJSValue<T7>(arguments[7]);
                arguments[1].AddRef();
arguments[2].AddRef();
arguments[3].AddRef();
arguments[4].AddRef();
arguments[5].AddRef();
arguments[6].AddRef();
arguments[7].AddRef();

                a(para1,para2,para3,para4,para5,para6,para7);
                arguments[1].Release();
arguments[2].Release();
arguments[3].Release();
arguments[4].Release();
arguments[5].Release();
arguments[6].Release();
arguments[7].Release();
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }


        private static Action<T1,T2,T3,T4,T5,T6,T7> FromJSMethod<T1,T2,T3,T4,T5,T6,T7>(IServiceNode node,JavaScriptValue value)
        {
            var converter = node.GetService<IJSValueConverterService>();
			IDisposable stub = node.GetService<IGCSyncService>().CreateJsGCWrapper(value);
            Action<T1,T2,T3,T4,T5,T6,T7> result = (T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6,T7 para7) =>
              {
                  JavaScriptValue p1 = converter.ToJSValue<T1>(para1);
JavaScriptValue p2 = converter.ToJSValue<T2>(para2);
JavaScriptValue p3 = converter.ToJSValue<T3>(para3);
JavaScriptValue p4 = converter.ToJSValue<T4>(para4);
JavaScriptValue p5 = converter.ToJSValue<T5>(para5);
JavaScriptValue p6 = converter.ToJSValue<T6>(para6);
JavaScriptValue p7 = converter.ToJSValue<T7>(para7);       
                  node.WithContext(()=>
                  {
                      var caller = node.GetService<ICallContextService>().Caller;
                      p1.AddRef();
p2.AddRef();
p3.AddRef();
p4.AddRef();
p5.AddRef();
p6.AddRef();
p7.AddRef();
                      value.CallFunction(caller,p1,p2,p3,p4,p5,p6,p7);
                      p1.Release();
p2.Release();
p3.Release();
p4.Release();
p5.Release();
p6.Release();
p7.Release();
                  });
				  GC.KeepAlive(stub);//keep referenced javascript value alive
              };
            return result;
        }



    }
}
