﻿

using System;
using System.Collections.Generic;
using ChakraCore.NET.API;
namespace ChakraCore.NET
{
public partial class JSValueBinding
{
        public void SetMethod(string name,Action a)
        {
            this.Converter.RegisterMethodConverter();
            this.ValueService.WriteProperty<Action>(this._jsValue,name, a);
        }

        public void SetFunction<TResult>(string name,Func<TResult> callback, Func<TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, TResult> tmp = (isConstruct) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback();
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback();
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1>(string name,Action<T1> a)
        {
            this.Converter.RegisterMethodConverter<T1>();
            this.ValueService.WriteProperty<Action<T1>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,TResult>(string name,Func<T1,TResult> callback, Func<T1,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,TResult> tmp = (isConstruct,para1) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1,T2>(string name,Action<T1,T2> a)
        {
            this.Converter.RegisterMethodConverter<T1,T2>();
            this.ValueService.WriteProperty<Action<T1,T2>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,T2,TResult>(string name,Func<T1,T2,TResult> callback, Func<T1,T2,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,T2,TResult> tmp = (isConstruct,para1,para2) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1,para2);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1,para2);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,T2,TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1,T2,T3>(string name,Action<T1,T2,T3> a)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3>();
            this.ValueService.WriteProperty<Action<T1,T2,T3>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,T2,T3,TResult>(string name,Func<T1,T2,T3,TResult> callback, Func<T1,T2,T3,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,T2,T3,TResult> tmp = (isConstruct,para1,para2,para3) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1,para2,para3);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1,para2,para3);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,T2,T3,TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1,T2,T3,T4>(string name,Action<T1,T2,T3,T4> a)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4>();
            this.ValueService.WriteProperty<Action<T1,T2,T3,T4>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,T2,T3,T4,TResult>(string name,Func<T1,T2,T3,T4,TResult> callback, Func<T1,T2,T3,T4,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,T2,T3,T4,TResult> tmp = (isConstruct,para1,para2,para3,para4) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1,para2,para3,para4);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1,para2,para3,para4);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,T2,T3,T4,TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1,T2,T3,T4,T5>(string name,Action<T1,T2,T3,T4,T5> a)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4,T5>();
            this.ValueService.WriteProperty<Action<T1,T2,T3,T4,T5>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,T2,T3,T4,T5,TResult>(string name,Func<T1,T2,T3,T4,T5,TResult> callback, Func<T1,T2,T3,T4,T5,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,T5,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,T2,T3,T4,T5,TResult> tmp = (isConstruct,para1,para2,para3,para4,para5) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1,para2,para3,para4,para5);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1,para2,para3,para4,para5);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,T2,T3,T4,T5,TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1,T2,T3,T4,T5,T6>(string name,Action<T1,T2,T3,T4,T5,T6> a)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4,T5,T6>();
            this.ValueService.WriteProperty<Action<T1,T2,T3,T4,T5,T6>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,T2,T3,T4,T5,T6,TResult>(string name,Func<T1,T2,T3,T4,T5,T6,TResult> callback, Func<T1,T2,T3,T4,T5,T6,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,T5,T6,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,T2,T3,T4,T5,T6,TResult> tmp = (isConstruct,para1,para2,para3,para4,para5,para6) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1,para2,para3,para4,para5,para6);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1,para2,para3,para4,para5,para6);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,T2,T3,T4,T5,T6,TResult>>(this._jsValue,name, tmp);
        }



        public void SetMethod<T1,T2,T3,T4,T5,T6,T7>(string name,Action<T1,T2,T3,T4,T5,T6,T7> a)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4,T5,T6,T7>();
            this.ValueService.WriteProperty<Action<T1,T2,T3,T4,T5,T6,T7>>(this._jsValue,name, a);
        }

        public void SetFunction<T1,T2,T3,T4,T5,T6,T7,TResult>(string name,Func<T1,T2,T3,T4,T5,T6,T7,TResult> callback, Func<T1,T2,T3,T4,T5,T6,T7,TResult> constructCallback=null)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,T5,T6,T7,TResult>();
            if (callback==null &&constructCallback==null)
            {
                throw new ArgumentException("callback and constructCallback cannot both be null");
            }
            Func<bool, T1,T2,T3,T4,T5,T6,T7,TResult> tmp = (isConstruct,para1,para2,para3,para4,para5,para6,para7) =>
               {
                   TResult result;
                   if (isConstruct)
                   {
                       if (constructCallback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support construct call");
                       }
                       else
                       {
                           result = constructCallback(para1,para2,para3,para4,para5,para6,para7);
                       }
                   }
                   else
                   {
                       if (callback==null)
                       {
                           throw new NotImplementedException(@"function {name} does not support direct call");
                       }
                       else
                       {
                           result = callback(para1,para2,para3,para4,para5,para6,para7);
                       }
                   }
                   return result;
               };
            this.ValueService.WriteProperty<Func<bool, T1,T2,T3,T4,T5,T6,T7,TResult>>(this._jsValue,name, tmp);
        }




    }
}
