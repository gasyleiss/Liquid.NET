﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Liquid.NET.Constants;

namespace Liquid.NET.Filters.Strings
{
    public class StripNewlinesFilter : FilterExpression<IExpressionConstant, StringValue>
    {

        public override StringValue ApplyTo(IExpressionConstant objectExpression)
        {
            return StringResult.Eval(objectExpression, x => Regex.Replace(x, "[^\u000A-\u000D]|\u2028|\u2029|\u0085", " "));
        }
        
    }
}
