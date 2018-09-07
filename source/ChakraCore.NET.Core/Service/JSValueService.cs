using ChakraCore.NET.API;
using System;

namespace ChakraCore.NET
{
    public class JSValueService : ServiceBase, IJSValueService
    {
        public JavaScriptValue JSValue_Undefined => this.contextSwitch.With<JavaScriptValue>(() =>
        {
            Native.ThrowIfError(Native.JsGetUndefinedValue(out var result));
            return result;
        });

        public JavaScriptValue JSValue_Null => this.contextSwitch.With<JavaScriptValue>(() =>
        {
            Native.ThrowIfError(Native.JsGetUndefinedValue(out var result));
            return result;
        });

        public JavaScriptValue JSValue_True => this.contextSwitch.With<JavaScriptValue>(() =>
        {
            Native.ThrowIfError(Native.JsGetTrueValue(out var result));
            return result;
        });

        public JavaScriptValue JSValue_False => this.contextSwitch.With<JavaScriptValue>(() =>
        {
            Native.ThrowIfError(Native.JsGetFalseValue(out var result));
            return result;
        });

        public JavaScriptValue JSGlobalObject => this.contextSwitch.With<JavaScriptValue>(() =>
        {
            Native.ThrowIfError(Native.JsGetGlobalObject(out var result));
            return result;
        });

        public object ReadProperty(JavaScriptValue target, JavaScriptPropertyId id, Type type)
        {
            return this.contextSwitch.With(() => this.converter.FromJSValue(type, target.GetProperty(id)));
        }

        public T ReadProperty<T>(JavaScriptValue target, JavaScriptPropertyId id)
        {
            return this.contextSwitch.With<T>(
                () =>
                {
                    return this.converter.FromJSValue<T>(target.GetProperty(id));
                });
            ;
        }

        public void WriteProperty<T>(JavaScriptValue target, JavaScriptPropertyId id, T value)
        {
            this.contextSwitch.With(
                () =>
                {
                    target.SetProperty(id, this.converter.ToJSValue<T>(value), true);
                });

            ;
        }
        public void WriteProperty(JavaScriptValue target, JavaScriptPropertyId id, Type type, object value)
        {
            this.contextSwitch.With(
                () =>
                {
                    target.SetProperty(id, this.converter.ToJSValue(type, value), true);
                });

            ;
        }

        public object ReadProperty(JavaScriptValue target, string id, Type type)
        {
            return this.contextSwitch.With<object>(
                () =>
                {
                    return this.converter.FromJSValue(type, target.GetProperty(JavaScriptPropertyId.FromString(id)));
                });
            ;
        }

        public T ReadProperty<T>(JavaScriptValue target, string id)
        {
            return this.contextSwitch.With<T>(
                () =>
                {
                    return this.converter.FromJSValue<T>(target.GetProperty(JavaScriptPropertyId.FromString(id)));
                });
            ;
        }

        public void WriteProperty(JavaScriptValue target, string id, Type type, object value)
        {
            this.contextSwitch.With(() =>
            {
                target.SetProperty(JavaScriptPropertyId.FromString(id), this.converter.ToJSValue(type, value), true);
            });

            ;
        }

        public void WriteProperty<T>(JavaScriptValue target, string id, T value)
        {
            this.contextSwitch.With(() =>
                {
                    target.SetProperty(JavaScriptPropertyId.FromString(id), this.converter.ToJSValue<T>(value), true);
                });

            ;
        }
        public JavaScriptValue CreateFunction(JavaScriptNativeFunction function, IntPtr callbackData)
        {
            return this.contextSwitch.With<JavaScriptValue>(() =>
            {
                var result = JavaScriptValue.CreateFunction(function, callbackData);
                this.serviceNode.GetService<IGCSyncService>().SyncWithJsValue(function, result);//keep delegate alive until related javascript value is released
                return result;
            });

        }

        public JavaScriptValue CreateObject()
        {
            return this.contextSwitch.With<JavaScriptValue>(() =>
            {
                return JavaScriptValue.CreateObject();
            });
        }

        public JavaScriptValue CreateExternalObject(IntPtr data, JavaScriptObjectFinalizeCallback finalizeCallback)
        {
            return this.contextSwitch.With<JavaScriptValue>(() =>
            {
                return JavaScriptValue.CreateExternalObject(data, finalizeCallback);
            });
        }

        public JavaScriptValue CallFunction(JavaScriptValue target, params JavaScriptValue[] para)
        {
            return this.contextSwitch.With<JavaScriptValue>(() =>
            {
                return target.CallFunction(para);
            });
        }

        public JavaScriptValue ConstructObject(JavaScriptValue target, params JavaScriptValue[] para)
        {
            return this.contextSwitch.With<JavaScriptValue>(() =>
            {
                return target.ConstructObject(para);
            });
        }

        public JavaScriptValue CreateArray(uint length)
        {
            return this.contextSwitch.With<JavaScriptValue>(() =>
            {
                return JavaScriptValue.CreateArray(length);
            });
        }

        public bool HasProperty(JavaScriptValue target, JavaScriptPropertyId id)
        {

            return this.contextSwitch.With<bool>(() =>
            {
                return target.HasProperty(id);
            });
        }

        public bool HasProperty(JavaScriptValue target, string id)
        {
            return this.contextSwitch.With<bool>(() =>
            {
                return target.HasProperty(JavaScriptPropertyId.FromString(id));
            });
        }

        public void ThrowIfErrorValue(JavaScriptValue value)
        {
            if (value.IsValid && value.ValueType == JavaScriptValueType.Error)
            {
                var message = this.ReadProperty<string>(value, "description");
                throw new JavaScriptFatalException(JavaScriptErrorCode.Fatal, message);
            }
        }

    }
}
