﻿using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification.Rules
{
    public class StringRuleVerification:IFingerVerification
    {
        public string Name { get; set; }
        public double MinLength { get; set; }

        /// <summary>
        /// string max length
        /// </summary>
        public double MaxLength { get; set; }

        /// <summary>
        /// the parameter is null
        /// </summary>
        public bool IsRequired { get; set; }

        public bool IsNull { get; set; }

        public StringRuleVerification(string parameterName, bool isNull, bool isRequired, double minLength,
            double maxLength)
        {
            IsNull = isNull;
            IsRequired = isRequired;
            MinLength = minLength;
            MaxLength = maxLength;
            Name = parameterName;
        }

        public bool Verification(ActionExecutingContext context)
        {
            var value = (string)context.ActionArguments[Name];
            if (value == null && IsRequired)
            {
                return false;
            }
            if (value == null && IsNull)
            {
                return false;
            }
            return value != null && (!(value.Length < MinLength) && !(value.Length > MaxLength));
        }
    }
}