using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebProjectExample.RouteConstraints
{
    //Custom Constraints which allows only cyrillic letters in the route name
    //We can do what ever we want with this constraints. Example -> check if the routeName exist in the database
    public class CyrillicRouteConstraints :IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var value = values.FirstOrDefault(x => x.Key == routeKey).Value.ToString();
            if (value == null)
            {
                return false;
            }

            var allowedCharacters = "абвгдежзийклмнопрстуфхцшщъьюя";

            foreach (char ch in value)
            {
                if (!allowedCharacters.Contains(char.ToLower(ch)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
