using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
namespace Finger.Verification
{
    public class FingerRuleForAttribute : ActionFilterAttribute

    {
        public object[] rules;
       override  public  void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
