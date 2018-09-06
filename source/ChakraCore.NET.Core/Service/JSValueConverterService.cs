using ChakraCore.NET.API;
using System;
using System.Collections.Generic;


namespace ChakraCore.NET
{
    public partial class JSValueConverterService : ServiceBase, IJSValueConverterService
    {
        private SortedDictionary<Type, Tuple<object, object>> converters = new SortedDictionary<Type, Tuple<object, object>>(TypeComparer.Instance);
        public JSValueConverterService()
        {
            this.initDefault();
            this.initDebugTypes();
        }

        public bool CanConvert<T>()
        {
            return this.converters.ContainsKey(typeof(T));
        }

        public bool CanConvert(Type t)
        {
            return this.converters.ContainsKey(t);
        }

        public void RegisterConverter<T>(toJSValueDelegate<T> toJSValue, fromJSValueDelegate<T> fromJSValue, bool throewIfExists = true)
        {
            if (this.CanConvert<T>())
            {
                if (throewIfExists)
                {
                    throw new ArgumentException($"type {typeof(T).FullName} already registered");
                }
                else
                {
                    return;
                }
            }
            this.converters.Add(typeof(T), new Tuple<object, object>(toJSValue, fromJSValue));
        }

        public void RegisterConverter(Type type, toJSValueDelegate toJSValue, fromJSValueDelegate fromJSValue, bool throwIfExists = true)
        {
            if (this.CanConvert(type))
            {
                if (throwIfExists)
                {
                    throw new ArgumentException($"type {type.FullName} already registered");
                }
                else
                {
                    return;
                }
            }
            this.converters.Add(type, new Tuple<object, object>(toJSValue, fromJSValue));
        }


        //public void RegisterStructConverter<T>(toJSValueDelegate<T> toJSValue, fromJSValueDelegate<T> fromJSValue) where T : struct
        //{
        //    RegisterConverter<T>(toJSValue, fromJSValue);
        //}

        public JavaScriptValue ToJSValue<T>(T value)
        {
            if (this.CanConvert<T>())
            {
                var f = (this.converters[typeof(T)].Item1 as toJSValueDelegate<T>);
                if (f == null)
                {
                    throw new NotImplementedException($"type {typeof(T).FullName} does not support convert to JSValue");
                }
                else
                {
                    return f(this.serviceNode, value);

                }

            }
            else
            {
                throw new NotImplementedException($"type {typeof(T).FullName} not registered for convertion");
            }
        }

        public JavaScriptValue ToJSValue(Type type, object value)
        {
            if (this.CanConvert(type))
            {
                var f = (this.converters[type].Item1 as toJSValueDelegate);
                if (f == null)
                {
                    throw new NotImplementedException($"type {type.FullName} does not support convert to JSValue");
                }
                else
                {
                    return f(this.serviceNode, value);

                }

            }
            else
            {
                throw new NotImplementedException($"type {type.FullName} not registered for convertion");
            }
        }

        public T FromJSValue<T>(JavaScriptValue value)
        {
            if (this.CanConvert<T>())
            {
                var f = (this.converters[typeof(T)].Item2 as fromJSValueDelegate<T>);
                if (f == null)
                {
                    throw new NotImplementedException($"type {typeof(T).FullName} does not support convert from JSValue");
                }
                else
                {
                    return f(this.serviceNode, value);
                }
            }
            else
            {
                throw new NotImplementedException($"type {typeof(T).FullName} not registered for convertion");
            }
        }

        public object FromJSValue(Type type, JavaScriptValue value)
        {
            if (this.CanConvert(type))
            {
                var f = (this.converters[type].Item2 as fromJSValueDelegate);
                if (f == null)
                {
                    throw new NotImplementedException($"type {type.FullName} does not support convert from JSValue");
                }
                else
                {
                    return f(this.serviceNode, value);
                }
            }
            else
            {
                throw new NotImplementedException($"type {type.FullName} not registered for convertion");
            }
        }
    }
}
