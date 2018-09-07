
using ChakraCore.NET.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChakraCore.NET
{
    public partial class JSValueBinding : ServiceConsumerBase
    {
        IJSValueConverterService Converter => this.ServiceNode.GetService<IJSValueConverterService>();
        IJSValueService ValueService => this.ServiceNode.GetService<IJSValueService>();
        readonly JavaScriptValue _jsValue;
        public JSValueBinding(IServiceNode parentNode, JavaScriptValue value) : base(parentNode, "JSValueBinding")
        {
            this._jsValue = value;
        }

        public void SetMethod(string name, Delegate a)
        {
            this.Converter.RegisterMethodConverter(a);
            this.ValueService.WriteProperty(this._jsValue, name, a.GetType(), a);
        }
    }
}
