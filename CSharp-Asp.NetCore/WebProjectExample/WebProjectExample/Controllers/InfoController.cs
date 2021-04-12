using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjectExample.Filters;

namespace WebProjectExample.Controllers
{
    //This filter is registered as attribute and it will works only for this controller
    //[AddHeaderActionFilter]

    //If we have constructor (dependency container) and we want to return data with the attribute we have to use
    [TypeFilter(typeof(AddHeaderActionFilterAttribute))]
    public class InfoController : Controller
    {
        //This filter is registered as attribute and it will works only for this action
        //[AddHeaderActionFilter]
        public IActionResult Time()
        {
            return this.Content(DateTime.Now.ToLongTimeString());
        }

        public IActionResult Date()
        {
            return this.Content(DateTime.Now.ToLongDateString());
        }
    }
}
