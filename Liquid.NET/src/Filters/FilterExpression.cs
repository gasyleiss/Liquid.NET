﻿using System;
using Liquid.NET.Constants;
using Liquid.NET.Utils;

namespace Liquid.NET.Filters
{
    public interface IFilterExpression
    {
        Type SourceType { get; }
        Type ResultType { get; }

        LiquidExpressionResult Apply(IExpressionConstant liquidExpression);
    };

    public interface IFilterExpression<in TSource, out TResult> : IFilterExpression
        where TSource : IExpressionConstant
        where TResult : IExpressionConstant
    {
        TResult Apply(TSource liquidExpression);
    };

    public abstract class FilterExpression<TSource, TResult> : IFilterExpression
        where TSource : IExpressionConstant
        where TResult : IExpressionConstant
    {

        // TODO: I don't think this should be virtual
        //public virtual TResult Apply(TSource liquidExpression)
        public virtual LiquidExpressionResult Apply(TSource option)
        {
            throw new Exception("Need to figure out how to do this part");
            //return option.Bind<LiquidExpressionResult>(x => ApplyTo((dynamic)x));
        }

        public LiquidExpressionResult Apply(IExpressionConstant liquidExpression)
        {
            throw new Exception("Need to figure out how to do this part");
            //return Apply((TSource)liquidExpression);
            //return Apply((Option<TSource>)liquidExpression);
        }

        /* override some or all of these ApplyTo functions */
        public virtual LiquidExpressionResult ApplyTo(IExpressionConstant liquidExpression) // todo: make this fallback abtstract
        {
            throw new NotImplementedException();
        }
        public virtual LiquidExpressionResult ApplyTo(NumericValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }
        public virtual LiquidExpressionResult ApplyTo(StringValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }
        public virtual LiquidExpressionResult ApplyTo(DictionaryValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }
        public virtual LiquidExpressionResult ApplyTo(ArrayValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }

        public virtual LiquidExpressionResult ApplyTo(BooleanValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }

        public virtual LiquidExpressionResult ApplyTo(DateValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }


        public virtual LiquidExpressionResult ApplyTo(GeneratorValue val)
        {
            //throw new Exception("Need to figure out how to do this part");
            return ApplyTo((IExpressionConstant)val);
        }

        public virtual LiquidExpressionResult ApplyToNil()
        {
            throw new Exception("TODO: FIgoure how to do tis part");
            //return new LiquidExpressionResult(Option<IExpressionConstant>.None);
        }

        public Type SourceType
        {
            get { return typeof(TSource); }
        }

        public Type ResultType
        {
            get { return typeof(TResult); }
        }

    }
}