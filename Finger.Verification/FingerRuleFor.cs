using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;
namespace Finger.Verification
{
    public class FingerRuleFor: ActionFilterAttribute
    {
       override  public  void OnActionExecuted(ActionExecutedContext context)
        {
            StringValues  testdsa;
            var   test = context.HttpContext.Request.Form.TryGetValue("userName",out testdsa);
            var test1 = context.ActionDescriptor.Parameters.Where(p => p.BindingInfo.BindingSource.Id.Equals("Query")).Select(p=>p.Name).ToArray();
                int a, b =1;
        }
    }
}
