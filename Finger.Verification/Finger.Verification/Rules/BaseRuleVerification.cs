using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification.Rules
{
    public class BaseRuleVerification:IFingerVerification
    {
        private string Name { get; set; }
        private bool IsRequired { get; set; }
        public BaseRuleVerification(string parameterNmae, bool isReauired)
        {
            Name = parameterNmae;
            IsRequired = isReauired;
        }

        public bool Verification(ActionExecutingContext context)
        {
            var value = context.ActionArguments[Name];
            return value != null || !IsRequired;
        }
    }
}