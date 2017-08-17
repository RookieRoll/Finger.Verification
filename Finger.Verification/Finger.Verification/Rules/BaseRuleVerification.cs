using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification.Rules
{
    internal class BaseRuleVerification:IFingerVerification
    {
        internal string Name { get; set; }
        internal bool IsRequired { get; set; }
        public BaseRuleVerification(string parameterName, bool isRequired)
        {
            Name = parameterName;
            IsRequired = isRequired;
        }

        public virtual bool Verification(ActionExecutingContext context)
        {
            var value = context.ActionArguments[Name];
            return value != null || !IsRequired;
        }
    }
}