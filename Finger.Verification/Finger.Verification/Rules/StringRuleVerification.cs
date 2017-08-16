using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification.Rules
{
    public class StringRuleVerification:FingerVerification
    {
        private readonly ActionExecutingContext _context;
        public string Name { get; set; }
        public double MinLength
        {
            get => MinLength;
            set => MinLength = double.MinValue;
        }

        /// <summary>
        /// string max length
        /// </summary>
        public double MaxLength
        {
            get => MaxLength;
            set { MaxLength = double.MaxValue; }
        }

        /// <summary>
        /// the parameter is null
        /// </summary>
        public bool IsRequired
        {
            get => IsRequired;
            set => IsRequired = true;
        }

        public bool IsNull
        {
            get => IsNull;
            set => IsNull = true;
        }

        public StringRuleVerification(string parameterName, bool? isNull, bool? isRequired, double? minLength,
            double? maxLength, ActionExecutingContext context)
        {
            if (isNull != null) IsNull = (bool) isNull;
            if (isRequired != null) IsRequired = (bool) isRequired;
            if (minLength != null) MinLength = (double) minLength;
            if (maxLength != null) MaxLength = (double) maxLength;
            _context = context;
            Name = parameterName;
        }

        public override bool Verification()
        {
            var value = _context.ActionArguments[Name];
            if (value == null && IsNull)
            {
                return false;
            }
            if (value.ToString().Length < MinLength || value.ToString().Length > MaxLength)
            {
                return false;
            }
            return true;
        }
    }
}