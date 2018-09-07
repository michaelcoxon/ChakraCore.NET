

using System;
using System.Collections.Generic;
using ChakraCore.NET.API;
namespace ChakraCore.NET
{
public static partial class JSValueConverterHelper
{

        public static void RegisterMethodConverter(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action>())
            {
                return;
            }
            service.RegisterConverter<Action>(ToJSMethod, FromJSMethod, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,TResult>>())
            {
                service.RegisterConverter<Func<bool,TResult>>(ToJSFunction<TResult>, FromJSFunction<TResult>,false);
            }
            if (!service.CanConvert<Func<TResult>>())
            {
                service.RegisterConverter<Func<TResult>>(ToJSCallbackFunction<TResult>, FromJSCallbackFunction<TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1>>(ToJSMethod<T1>, FromJSMethod<T1>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,TResult>>(ToJSFunction<T1,TResult>, FromJSFunction<T1,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,TResult>>())
            {
                service.RegisterConverter<Func<T1,TResult>>(ToJSCallbackFunction<T1,TResult>, FromJSCallbackFunction<T1,TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1,T2>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1,T2>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1,T2>>(ToJSMethod<T1,T2>, FromJSMethod<T1,T2>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,T2,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,T2,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,T2,TResult>>(ToJSFunction<T1,T2,TResult>, FromJSFunction<T1,T2,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,T2,TResult>>())
            {
                service.RegisterConverter<Func<T1,T2,TResult>>(ToJSCallbackFunction<T1,T2,TResult>, FromJSCallbackFunction<T1,T2,TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1,T2,T3>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1,T2,T3>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1,T2,T3>>(ToJSMethod<T1,T2,T3>, FromJSMethod<T1,T2,T3>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,T2,T3,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,T2,T3,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,T2,T3,TResult>>(ToJSFunction<T1,T2,T3,TResult>, FromJSFunction<T1,T2,T3,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,T2,T3,TResult>>())
            {
                service.RegisterConverter<Func<T1,T2,T3,TResult>>(ToJSCallbackFunction<T1,T2,T3,TResult>, FromJSCallbackFunction<T1,T2,T3,TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1,T2,T3,T4>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1,T2,T3,T4>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1,T2,T3,T4>>(ToJSMethod<T1,T2,T3,T4>, FromJSMethod<T1,T2,T3,T4>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,T2,T3,T4,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,T2,T3,T4,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,T2,T3,T4,TResult>>(ToJSFunction<T1,T2,T3,T4,TResult>, FromJSFunction<T1,T2,T3,T4,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,T2,T3,T4,TResult>>())
            {
                service.RegisterConverter<Func<T1,T2,T3,T4,TResult>>(ToJSCallbackFunction<T1,T2,T3,T4,TResult>, FromJSCallbackFunction<T1,T2,T3,T4,TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1,T2,T3,T4,T5>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1,T2,T3,T4,T5>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1,T2,T3,T4,T5>>(ToJSMethod<T1,T2,T3,T4,T5>, FromJSMethod<T1,T2,T3,T4,T5>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,T2,T3,T4,T5,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,T2,T3,T4,T5,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,T2,T3,T4,T5,TResult>>(ToJSFunction<T1,T2,T3,T4,T5,TResult>, FromJSFunction<T1,T2,T3,T4,T5,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,T2,T3,T4,T5,TResult>>())
            {
                service.RegisterConverter<Func<T1,T2,T3,T4,T5,TResult>>(ToJSCallbackFunction<T1,T2,T3,T4,T5,TResult>, FromJSCallbackFunction<T1,T2,T3,T4,T5,TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1,T2,T3,T4,T5,T6>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1,T2,T3,T4,T5,T6>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1,T2,T3,T4,T5,T6>>(ToJSMethod<T1,T2,T3,T4,T5,T6>, FromJSMethod<T1,T2,T3,T4,T5,T6>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,T2,T3,T4,T5,T6,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,T2,T3,T4,T5,T6,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,T2,T3,T4,T5,T6,TResult>>(ToJSFunction<T1,T2,T3,T4,T5,T6,TResult>, FromJSFunction<T1,T2,T3,T4,T5,T6,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,T2,T3,T4,T5,T6,TResult>>())
            {
                service.RegisterConverter<Func<T1,T2,T3,T4,T5,T6,TResult>>(ToJSCallbackFunction<T1,T2,T3,T4,T5,T6,TResult>, FromJSCallbackFunction<T1,T2,T3,T4,T5,T6,TResult>,false);
            }
            
            
        }

        



        public static void RegisterMethodConverter<T1,T2,T3,T4,T5,T6,T7>(this IJSValueConverterService service)
        {
            if (service.CanConvert<Action<T1,T2,T3,T4,T5,T6,T7>>())
            {
                return;
            }
            service.RegisterConverter<Action<T1,T2,T3,T4,T5,T6,T7>>(ToJSMethod<T1,T2,T3,T4,T5,T6,T7>, FromJSMethod<T1,T2,T3,T4,T5,T6,T7>, false);
        }
        

        //register direct call delegate and callback delegate
        public static void RegisterFunctionConverter<T1,T2,T3,T4,T5,T6,T7,TResult>(this IJSValueConverterService service)
        {
            if (!service.CanConvert<Func<bool,T1,T2,T3,T4,T5,T6,T7,TResult>>())
            {
                service.RegisterConverter<Func<bool,T1,T2,T3,T4,T5,T6,T7,TResult>>(ToJSFunction<T1,T2,T3,T4,T5,T6,T7,TResult>, FromJSFunction<T1,T2,T3,T4,T5,T6,T7,TResult>,false);
            }
            if (!service.CanConvert<Func<T1,T2,T3,T4,T5,T6,T7,TResult>>())
            {
                service.RegisterConverter<Func<T1,T2,T3,T4,T5,T6,T7,TResult>>(ToJSCallbackFunction<T1,T2,T3,T4,T5,T6,T7,TResult>, FromJSCallbackFunction<T1,T2,T3,T4,T5,T6,T7,TResult>,false);
            }
            
            
        }

        



    }
}
