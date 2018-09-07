﻿
using ChakraCore.NET.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ChakraCore.NET
{
    public static partial class JSValueConverterHelper
    {
        public static void RegisterMethodConverter(this IJSValueConverterService service, Delegate action)
        {
            var actionType = action.GetType();

            if (service.CanConvert(actionType))
            {
                return;
            }
            service.RegisterConverter(actionType, ToJSMethod, FromJSMethod, false);
        }

        public static void RegisterStructConverter<T>(this IJSValueConverterService service, Action<JSValue, T> toJSValue, Func<JSValue, T> fromJSValue) where T : struct
        {
            service.RegisterConverter<T>(
                (node, value) =>
                {
                    JavaScriptValue jsObj = node.GetService<IJSValueService>().CreateObject();
                    JSValue v = new JSValue(node, jsObj);
                    toJSValue(v, value);
                    return jsObj;
                },
                (node, value) =>
                {
                    JSValue v = new JSValue(node, value);
                    return fromJSValue(v);
                }
                );
        }

        public static void RegisterProxyConverter<T>(this IJSValueConverterService service, Action<JSValueBinding, T, IServiceNode> createBinding) where T : class
        {

            toJSValueDelegate<T> tojs = (IServiceNode node, T value) =>
            {
                return node.GetService<IContextSwitchService>().With(() =>
                {
                    var result = JavaScriptValue.CreateExternalObject(IntPtr.Zero,null);
                    JSValueBinding binding = new JSValueBinding(node, result);
                    var handle=node.GetService<IGCSyncService>().SyncWithJsValue(value, result);
                    result.ExternalData = GCHandle.ToIntPtr(handle);//save the object reference to javascript values's external data
                    createBinding?.Invoke(binding, value, node);
                    return result;
                });

            };
            fromJSValueDelegate<T> fromjs = (IServiceNode node, JavaScriptValue value) =>
            {
                if (value.HasExternalData)
                {
                    GCHandle handle = GCHandle.FromIntPtr(value.ExternalData);
                    return handle.Target as T;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Convert from jsValue to proxy object failed, jsValue does not have a linked CLR object");
                }

            };
            service.RegisterConverter<T>(tojs, fromjs);
        }

        public static void RegisterArrayConverter<T>(this IJSValueConverterService service)
        {
            toJSValueDelegate<IEnumerable<T>> tojs = (node, value) =>
            {
                return node.WithContext<JavaScriptValue>(() =>
                {
                    var result = node.GetService<IJSValueService>().CreateArray(Convert.ToUInt32(value.Count()));
                    int index = 0;
                    foreach (T item in value)
                    {
                        result.SetIndexedProperty(service.ToJSValue<int>(index++), service.ToJSValue<T>(item));
                    }
                    return result;
                }
                );
            };
            fromJSValueDelegate<IEnumerable<T>> fromjs = (node, value) =>
            {
                return node.WithContext<IEnumerable<T>>(() =>
                {
                    var jsValueService = node.GetService<IJSValueService>();
                    var length = service.FromJSValue<int>(value.GetProperty(JavaScriptPropertyId.FromString("length")));
                    List<T> result = new List<T>(length);//copy the data to avoid context switch in user code
                    for (int i = 0; i < length; i++)
                    {
                        result.Add(
                            service.FromJSValue<T>(value.GetIndexedProperty(
                                        service.ToJSValue<int>(i))
                                        )
                                 );
                    }
                    return result;
                }
                );
            };
            service.RegisterConverter<IEnumerable<T>>(tojs, fromjs, false);
        }


        private static JavaScriptValue ToJSMethod(IServiceNode node, object a)
        {
            var action = (Delegate)a;
            var parameters = action.Method.GetParameters();

            var converter = node.GetService<IJSValueConverterService>();
            var jsValueService = node.GetService<IJSValueService>();
            JavaScriptValue f(JavaScriptValue callee, bool isConstructCall, JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
            {
                if (argumentCount != parameters.Length + 1)
                {
                    throw new InvalidOperationException("call from javascript did not pass enough parameters");
                }
                var args = new List<object>();

                for (var i = 0; i < parameters.Length; i++)
                {
                    args.Add(converter.FromJSValue(parameters[i].ParameterType, arguments[i + 1]));
                    arguments[i + 1].AddRef();
                }

                action.DynamicInvoke(args.ToArray());

                for (var i = 0; i < parameters.Length; i++)
                {
                    arguments[i + 1].Release();
                }
                return jsValueService.JSValue_Undefined;
            }

            return jsValueService.CreateFunction(f, IntPtr.Zero);
        }
    }
}
