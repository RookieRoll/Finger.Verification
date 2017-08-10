using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finger.Verification.Rules.String
{
    public class StringRuleAttribute : ActionFilterAttribute
    {
        public int MaxLength { get; set; } = int.MaxValue;
        public int MinLength { get; set; } = default(int);
        public string PropName { get; set; }
        public string ErrorMessage { get; set; }
        public bool AllowEmpty { get; set; } = false;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (MaxLength < MinLength)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? "参数设置错误" : ErrorMessage);
                return;
            }
            //获取到该属性的值
            var propValue = context.ActionArguments.Where(m => m.Key.Equals(PropName));
            if (propValue == null)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? "该值不存在" : ErrorMessage);
                return;
            }
            var value = propValue.SingleOrDefault().Value as string;
            //如果允许字符串为空
            if (AllowEmpty)
            {
            }
            else
            {

            }
            base.OnActionExecuting(context);
        }

    }
}
