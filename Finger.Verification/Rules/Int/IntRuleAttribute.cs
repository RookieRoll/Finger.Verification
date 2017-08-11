using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finger.Verification.Rules.Int
{
    public class IntRuleAttribute : ActionFilterAttribute
    {
        public float MaxValue { get; set; } = float.MaxValue;
        public float MinValue { get; set; } = float.MinValue;
        public string PropName { get; private set; }
        public string ErrorMessage { get; set; }

        public IntRuleAttribute(string propName)
        {
            PropName = propName;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //如果设置的最大值小于设置的最小值，判断错误
            if (MinValue < MaxValue)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? "最大值不能小于最小值" : ErrorMessage);
                return;
            }
            //获取到该属性的值
            var temp = context.ActionArguments.Where(m => m.Key.Equals(PropName));
            if (temp.Count() == 0)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? "没有找到该参数" : ErrorMessage);
                return;
            }
            var value = temp.SingleOrDefault().Value as int?;
            if (value == null)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? "该参数的数据不能为空" : ErrorMessage);
                return;
            }
            //判断只是不是在给定范围内
            if (value > MaxValue && value < MinValue)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? "该参数的数据不能为空" : ErrorMessage);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
