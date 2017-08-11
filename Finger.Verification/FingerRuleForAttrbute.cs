using Finger.Verification.Rules;
using Finger.Verification.Rules.String;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Reflection;

namespace Finger.Verification
{
    public class FingerRuleForAttrbute : ActionFilterAttribute
    {
        public ValidateProps[] props;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requestMethod = context.HttpContext.Request.Path.Value.Split('/').Last();
            MethodInfo method = context.Controller.GetType().GetMethod(requestMethod);//获取当前方法
            var methodParams = method.GetParameters();//获取当前方法的所有参数

            foreach(var item in props)
            {
                var propName = item.PropName;//当前参数名称
                if (methodParams.Any(m => m.Name.Equals(propName)))
                {
                    //获取当前字段的类型
                    var propType = methodParams
                        .Where(m => m.Name.Equals(propName))
                        .SingleOrDefault()
                        .ParameterType;

                    //获取当前所需的值
                    var value = context.ActionArguments[propName];

                    //参数类型选择
                    if (propType.Equals(typeof(string)))
                    {
                        var tempValue = value as string;
                        item.IsValidate(context);
                    }
                    else if (propType.Equals(typeof(int)))
                    {

                    }
                    else if (propType.Equals(typeof(float)))
                    {

                    }
                }

            }

        }
    }
}
