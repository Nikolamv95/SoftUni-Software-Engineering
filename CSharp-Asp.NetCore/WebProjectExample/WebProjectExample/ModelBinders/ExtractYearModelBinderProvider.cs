using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebProjectExample.ModelBinders
{
    public class ExtractYearModelBinderProvider : IModelBinderProvider
    {
        //Its custom global ModelProvider. It will load only if find input property with name Year and data type Int.
        //If the condition is true will return new ExtractYearModelBinder
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context?.Metadata?.Name?.ToLower() == "year" && context?.Metadata?.ModelType == typeof(int))
            {
                return new ExtractYearModelBinder();
            }

            return null;
        }
    }
}
