using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebProjectExample.Filters
{
    public class MyAutFilter : IAuthorizationFilter
    {
        //This is the first filter which we hit Authorization OnAuthorization
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
