using Microsoft.AspNetCore.Mvc.Filters;

namespace Finger.Verification
{
    public class FingerRuleForAttribute:ActionFilterAttribute
    {
        private ActionExecutingContext _context;
        
        /// <summary>
        /// int,float,double minvalue
        /// </summary>
        public double MinValue
        {
            get=>MinValue;
            set => MinValue = double.MinValue;
        }

        /// <summary>
        /// int,float,double Maxvalue
        /// </summary>
        public double MaxValue
        {
            get=>MaxValue;
            set => MaxValue = double.MaxValue;
        }

        /// <summary>
        /// string min length
        /// </summary>
        public double MinLength
        {
            get=>MinLength; 
            set=>MinLength =double.MinValue;
        }

        /// <summary>
        /// string max length
        /// </summary>
        public double MaxLength
        {
            get=>MaxLength;
            set { MaxLength = double.MaxValue; }
        }

        /// <summary>
        /// the parameter is null
        /// </summary>
        public bool IsRequired
        {
            get => IsRequired;
            set => IsRequired = true;
        }

        public bool IsNull
        {
            get => IsNull;
            set => IsNull = true;
        }

        public FingerRuleForAttribute(string parameterName,bool?isNull,bool? isRequired,double? minLength,double? maxLength)
        {
            //string verification
            
        }

        public FingerRuleForAttribute(string parameterName,bool? isRequired, double? minValue, double? maxValue)
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this._context = context;
        }
    }
}