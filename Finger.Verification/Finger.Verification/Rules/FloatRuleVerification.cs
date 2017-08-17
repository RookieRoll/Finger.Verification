using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace Finger.Verification.Rules
{
    internal class FloatRuleVerification : BaseRuleVerification
    {
        internal float MinValue { get; set; }
        internal float MaxValue { get; set; }

        public FloatRuleVerification(string parameterNmae, bool isRequired, float minValue, float maxValue) : base(
            parameterNmae, isRequired)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public override bool Verification(ActionExecutingContext context)
        {
            if (MaxValue < MinValue)
                return false;
            var value = default(float?);
            try
            {
                value = context.ActionArguments[Name] as float?;
            }
            catch (KeyNotFoundException ex)
            {
                return false;
            }

            if (value == null)
                return false;
            return (value <= MaxValue && value >= MinValue);
        }
    }
}