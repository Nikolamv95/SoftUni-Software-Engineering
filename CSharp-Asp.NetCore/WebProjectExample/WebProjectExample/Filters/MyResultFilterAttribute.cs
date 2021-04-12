using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebProjectExample.Filters
{
    //This is the forth filter which we hit
    public class MyResultFilterAttribute : ResultFilterAttribute
    {
        //Firstly wew will hit OnResultExecuting method and after it we will enter in to the view
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        //After we have the result from the view we enter in to the OnResultExecuted filter 
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
    }
}
