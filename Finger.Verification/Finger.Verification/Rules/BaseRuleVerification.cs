using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification.Rules
{
    public class BaseRuleVerification:IFingerVerification
    {
        public bool Verification(ActionExecutingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}