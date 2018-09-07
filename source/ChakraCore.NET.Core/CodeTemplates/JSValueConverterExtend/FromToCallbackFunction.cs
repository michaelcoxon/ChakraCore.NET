

using System;
using System.Collections.Generic;
using ChakraCore.NET.API;
namespace ChakraCore.NET
{
public static partial class JSValueConverterHelper
{
        private static Func<TResult> FromJSCallbackFunction<TResult>(IServiceNode node, JavaScriptValue value)
        {
            return () =>
            {
                return FromJSFunction<TResult>(node, value)(false);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<TResult> (IServiceNode node, Func<TResult> callback)
        {
            return ToJSFunction<TResult>(node, (b) =>
              {
                  return callback();
              }
            );
        }



        private static Func<T1,TResult> FromJSCallbackFunction<T1,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1) =>
            {
                return FromJSFunction<T1,TResult>(node, value)(false,para1);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,TResult> (IServiceNode node, Func<T1,TResult> callback)
        {
            return ToJSFunction<T1,TResult>(node, (b,para1) =>
              {
                  return callback(para1);
              }
            );
        }



        private static Func<T1,T2,TResult> FromJSCallbackFunction<T1,T2,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1,T2 para2) =>
            {
                return FromJSFunction<T1,T2,TResult>(node, value)(false,para1,para2);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,T2,TResult> (IServiceNode node, Func<T1,T2,TResult> callback)
        {
            return ToJSFunction<T1,T2,TResult>(node, (b,para1,para2) =>
              {
                  return callback(para1,para2);
              }
            );
        }



        private static Func<T1,T2,T3,TResult> FromJSCallbackFunction<T1,T2,T3,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1,T2 para2,T3 para3) =>
            {
                return FromJSFunction<T1,T2,T3,TResult>(node, value)(false,para1,para2,para3);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,T2,T3,TResult> (IServiceNode node, Func<T1,T2,T3,TResult> callback)
        {
            return ToJSFunction<T1,T2,T3,TResult>(node, (b,para1,para2,para3) =>
              {
                  return callback(para1,para2,para3);
              }
            );
        }



        private static Func<T1,T2,T3,T4,TResult> FromJSCallbackFunction<T1,T2,T3,T4,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1,T2 para2,T3 para3,T4 para4) =>
            {
                return FromJSFunction<T1,T2,T3,T4,TResult>(node, value)(false,para1,para2,para3,para4);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,T2,T3,T4,TResult> (IServiceNode node, Func<T1,T2,T3,T4,TResult> callback)
        {
            return ToJSFunction<T1,T2,T3,T4,TResult>(node, (b,para1,para2,para3,para4) =>
              {
                  return callback(para1,para2,para3,para4);
              }
            );
        }



        private static Func<T1,T2,T3,T4,T5,TResult> FromJSCallbackFunction<T1,T2,T3,T4,T5,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1,T2 para2,T3 para3,T4 para4,T5 para5) =>
            {
                return FromJSFunction<T1,T2,T3,T4,T5,TResult>(node, value)(false,para1,para2,para3,para4,para5);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,T2,T3,T4,T5,TResult> (IServiceNode node, Func<T1,T2,T3,T4,T5,TResult> callback)
        {
            return ToJSFunction<T1,T2,T3,T4,T5,TResult>(node, (b,para1,para2,para3,para4,para5) =>
              {
                  return callback(para1,para2,para3,para4,para5);
              }
            );
        }



        private static Func<T1,T2,T3,T4,T5,T6,TResult> FromJSCallbackFunction<T1,T2,T3,T4,T5,T6,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6) =>
            {
                return FromJSFunction<T1,T2,T3,T4,T5,T6,TResult>(node, value)(false,para1,para2,para3,para4,para5,para6);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,T2,T3,T4,T5,T6,TResult> (IServiceNode node, Func<T1,T2,T3,T4,T5,T6,TResult> callback)
        {
            return ToJSFunction<T1,T2,T3,T4,T5,T6,TResult>(node, (b,para1,para2,para3,para4,para5,para6) =>
              {
                  return callback(para1,para2,para3,para4,para5,para6);
              }
            );
        }



        private static Func<T1,T2,T3,T4,T5,T6,T7,TResult> FromJSCallbackFunction<T1,T2,T3,T4,T5,T6,T7,TResult>(IServiceNode node, JavaScriptValue value)
        {
            return (T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6,T7 para7) =>
            {
                return FromJSFunction<T1,T2,T3,T4,T5,T6,T7,TResult>(node, value)(false,para1,para2,para3,para4,para5,para6,para7);
            };
        }

        private static JavaScriptValue ToJSCallbackFunction<T1,T2,T3,T4,T5,T6,T7,TResult> (IServiceNode node, Func<T1,T2,T3,T4,T5,T6,T7,TResult> callback)
        {
            return ToJSFunction<T1,T2,T3,T4,T5,T6,T7,TResult>(node, (b,para1,para2,para3,para4,para5,para6,para7) =>
              {
                  return callback(para1,para2,para3,para4,para5,para6,para7);
              }
            );
        }




    }
}
