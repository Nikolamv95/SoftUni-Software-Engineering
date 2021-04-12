using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using WebProjectExample.Services;

namespace WebProjectExample.Filters
{

    //This is the third filter which we hit!

    //If we want to register the filter as attribute it should inherit the base Attribute class
    public class AddHeaderActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly IShortStringService shortStringService;

        public AddHeaderActionFilterAttribute(IShortStringService shortStringService)
        {
            this.shortStringService = shortStringService;
        }


        //The ActionExecutingContext context has different values and properties in both methods, because in the method OnActionExecuting
        //the data is different because the method will be executed before the real action, and after the action is executed
        //the method OnActionExecuted will have new data


        //Filter -> Before executing the action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info-Action-Name", context.ActionDescriptor.DisplayName);
        }

        //Filter -> After the action is executed. We enter here after the execution of the real action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info-Result-Type", context.Result.GetType().Name);
        }
    }
}
