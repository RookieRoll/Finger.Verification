using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification
{
    public interface IFingerVerification
    {
         bool Verification(ActionExecutingContext context);
    }
}