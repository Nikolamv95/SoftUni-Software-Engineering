using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebProjectExample.Filters
{
    public class MyResourceFilter : IResourceFilter
    {
        //This is the second filter which we hit Resource Filter
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        //We enter this filter after OnResultExecuted filter. This is the last filter which we hit and after it we return the response
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
