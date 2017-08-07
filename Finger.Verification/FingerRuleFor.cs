using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;
namespace Finger.Verification
{
    public class FingerRuleFor: ActionFilterAttribute
    {
       override  public  void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
