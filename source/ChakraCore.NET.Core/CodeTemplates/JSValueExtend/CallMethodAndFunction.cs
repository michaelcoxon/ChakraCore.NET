﻿

using System;
using System.Collections.Generic;
using ChakraCore.NET.API;
namespace ChakraCore.NET
{
public partial class JSValue
{
        public void CallMethod(string name )
        {
            this.Converter.RegisterMethodConverter();
            var a = this.ValueService.ReadProperty<Action>(ReferenceValue,name);
            a();
        }

        public TResult CallFunction<TResult>(string name , bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,TResult>>(ReferenceValue,name);
            return a(isConstructCall);
        }



        public void CallMethod<T1>(string name ,T1 para1)
        {
            this.Converter.RegisterMethodConverter<T1>();
            var a = this.ValueService.ReadProperty<Action<T1>>(ReferenceValue,name);
            a(para1);
        }

        public TResult CallFunction<T1,TResult>(string name ,T1 para1, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1);
        }



        public void CallMethod<T1,T2>(string name ,T1 para1,T2 para2)
        {
            this.Converter.RegisterMethodConverter<T1,T2>();
            var a = this.ValueService.ReadProperty<Action<T1,T2>>(ReferenceValue,name);
            a(para1,para2);
        }

        public TResult CallFunction<T1,T2,TResult>(string name ,T1 para1,T2 para2, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,T2,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1,para2);
        }



        public void CallMethod<T1,T2,T3>(string name ,T1 para1,T2 para2,T3 para3)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3>();
            var a = this.ValueService.ReadProperty<Action<T1,T2,T3>>(ReferenceValue,name);
            a(para1,para2,para3);
        }

        public TResult CallFunction<T1,T2,T3,TResult>(string name ,T1 para1,T2 para2,T3 para3, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,T2,T3,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1,para2,para3);
        }



        public void CallMethod<T1,T2,T3,T4>(string name ,T1 para1,T2 para2,T3 para3,T4 para4)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4>();
            var a = this.ValueService.ReadProperty<Action<T1,T2,T3,T4>>(ReferenceValue,name);
            a(para1,para2,para3,para4);
        }

        public TResult CallFunction<T1,T2,T3,T4,TResult>(string name ,T1 para1,T2 para2,T3 para3,T4 para4, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,T2,T3,T4,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1,para2,para3,para4);
        }



        public void CallMethod<T1,T2,T3,T4,T5>(string name ,T1 para1,T2 para2,T3 para3,T4 para4,T5 para5)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4,T5>();
            var a = this.ValueService.ReadProperty<Action<T1,T2,T3,T4,T5>>(ReferenceValue,name);
            a(para1,para2,para3,para4,para5);
        }

        public TResult CallFunction<T1,T2,T3,T4,T5,TResult>(string name ,T1 para1,T2 para2,T3 para3,T4 para4,T5 para5, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,T5,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,T2,T3,T4,T5,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1,para2,para3,para4,para5);
        }



        public void CallMethod<T1,T2,T3,T4,T5,T6>(string name ,T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4,T5,T6>();
            var a = this.ValueService.ReadProperty<Action<T1,T2,T3,T4,T5,T6>>(ReferenceValue,name);
            a(para1,para2,para3,para4,para5,para6);
        }

        public TResult CallFunction<T1,T2,T3,T4,T5,T6,TResult>(string name ,T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,T5,T6,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,T2,T3,T4,T5,T6,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1,para2,para3,para4,para5,para6);
        }



        public void CallMethod<T1,T2,T3,T4,T5,T6,T7>(string name ,T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6,T7 para7)
        {
            this.Converter.RegisterMethodConverter<T1,T2,T3,T4,T5,T6,T7>();
            var a = this.ValueService.ReadProperty<Action<T1,T2,T3,T4,T5,T6,T7>>(ReferenceValue,name);
            a(para1,para2,para3,para4,para5,para6,para7);
        }

        public TResult CallFunction<T1,T2,T3,T4,T5,T6,T7,TResult>(string name ,T1 para1,T2 para2,T3 para3,T4 para4,T5 para5,T6 para6,T7 para7, bool isConstructCall=false)
        {
            this.Converter.RegisterFunctionConverter<T1,T2,T3,T4,T5,T6,T7,TResult>();
            var a = this.ValueService.ReadProperty<Func<bool ,T1,T2,T3,T4,T5,T6,T7,TResult>>(ReferenceValue,name);
            return a(isConstructCall,para1,para2,para3,para4,para5,para6,para7);
        }




    }
}
