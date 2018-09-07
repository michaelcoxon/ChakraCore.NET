
using ChakraCore.NET.API;
using System;

namespace ChakraCore.NET
{
    public partial class JSValue : ServiceConsumerBase
    {
        protected IJSValueConverterService Converter => this.ServiceNode.GetService<IJSValueConverterService>();
        protected IJSValueService ValueService => this.ServiceNode.GetService<IJSValueService>();

        public JSValueBinding Binding { get; private set; }
        public JavaScriptValue ReferenceValue { get; private set; }

        public JSValue(IServiceNode parentNode, JavaScriptValue value) : base(parentNode, "JSValue")
        {
            this.ReferenceValue = value;
            this.ServiceNode.PushService<ICallContextService>(new CallContextService(value));
            //inject service
            this.Binding = new JSValueBinding(this.ServiceNode, value);//binding will create a branch of current service node to persistent hold all delegates created by binding function

        }

        public T ReadProperty<T>(JavaScriptPropertyId id)
        {
            return this.ValueService.ReadProperty<T>(this.ReferenceValue, id);
        }

        public void WriteProperty<T>(JavaScriptPropertyId id, T value)
        {
            this.ValueService.WriteProperty(this.ReferenceValue, id, value);
        }

        public T ReadProperty<T>(string id)
        {
            return this.ValueService.ReadProperty<T>(this.ReferenceValue, id);
        }

        public void WriteProperty<T>(string id, T value)
        {
            this.ValueService.WriteProperty(this.ReferenceValue, id, value);
        }


        public object ReadProperty(JavaScriptPropertyId id, Type type)
        {
            return this.ValueService.ReadProperty(this.ReferenceValue, id, type);
        }

        public void WriteProperty(JavaScriptPropertyId id, Type type, object value)
        {
            this.ValueService.WriteProperty(this.ReferenceValue, id, type, value);
        }
        public object ReadProperty(string id, Type type)
        {
            return this.ValueService.ReadProperty(this.ReferenceValue, id, type);
        }

        public void WriteProperty(string id, Type type, object value)
        {
            this.ValueService.WriteProperty(this.ReferenceValue, id, type, value);
        }
    }
}
