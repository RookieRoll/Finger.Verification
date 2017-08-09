using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Finger.Verification.Rules.Float
{
    public class FloatRuleAttribute : ActionFilterAttribute
    {
        public float MaxValue { get; set; } = float.MaxValue;
        public float MinValue { get; set; } = float.MinValue;
        public string PropName { get; private set; }
        public string ErrorMessage { get; set; }

        public FloatRuleAttribute(string propName)
        {
            PropName = propName;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (MinValue < MaxValue)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? ErrorMessage : "最大值不能小于最小值");
                return;
            }
            //获取到该属性的值
            var temp = context.ActionArguments.Where(m => m.Key.Equals(PropName));
            if (temp.Count() == 0)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? ErrorMessage : "没有找到该参数");
                return;
            }

            var value = temp.SingleOrDefault().Value as float?;
            if(value==null)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? ErrorMessage : "该参数的数据不能为空");
                return;
            }
            if(value>MaxValue&&value<MinValue)
            {
                context.Result = new JsonResult(string.IsNullOrWhiteSpace(ErrorMessage) ? ErrorMessage : "该参数的数据不能为空");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
