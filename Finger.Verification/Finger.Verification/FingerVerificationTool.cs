using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification
{
    public abstract class FingerVerificationTool
    {
        public abstract bool Verification(ActionExecutingContext context);
    }
}