using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace WebProjectExample.ModelBinders
{
    public class ExtractYearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext context)
        {
            var value = context.ValueProvider.GetValue("firstCooked").FirstValue;

            context.Result = DateTime.TryParse(value, out var valueAsDateTime) 
                ? ModelBindingResult.Success(valueAsDateTime.Year) 
                : ModelBindingResult.Failed();

            return Task.CompletedTask;
        }
    }
}
