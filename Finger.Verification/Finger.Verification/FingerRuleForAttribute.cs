using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Finger.Verification.Rules;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis;

namespace Finger.Verification
{
    public class FingerRuleForAttribute:ActionFilterAttribute
    {
        private readonly IFingerVerification _verifcation;

        
        /// <summary>
        /// base rule verification 
        /// </summary>
        /// <param name="parameterNmae"></param>
        /// <param name="isRequired"></param>
        public FingerRuleForAttribute(string parameterNmae, bool isRequired)
        {
            //base verification 
            _verifcation = new BaseRuleVerification(parameterNmae,isRequired);
        }
         
        /// <summary>
        /// string rule verification
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="isNull"></param>
        /// <param name="isRequired"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        public FingerRuleForAttribute(string parameterName,bool isNull,bool  isRequired,double minLength=1,double maxLength=double.MaxValue)
        {
            //string verification
            _verifcation = new StringRuleVerification(parameterName,isNull,isRequired,minLength,maxLength);
        }
        /// <summary>
        /// int ruleverification    
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="isRequired"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public FingerRuleForAttribute(string parameterName,bool isRequired, double minValue=double.MinValue, double maxValue=double.MaxValue)
        {
            _verifcation=new FloatRuleVerification(parameterName,isRequired,(float)minValue,(float)maxValue);
            //int verification
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_verifcation.Verification(context))
            {
                throw new HttpRequestException(HttpStatusCode.InternalServerError.ToString());
            }
        }
    }
}