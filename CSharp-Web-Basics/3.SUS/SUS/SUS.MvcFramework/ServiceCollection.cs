using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUS.MvcFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, Type> dependancyContainer = new Dictionary<Type, Type>();

        public void Add<TSource, TDestination>()
        {
            this.dependancyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (this.dependancyContainer.ContainsKey(type))
            {
               type = this.dependancyContainer[type];
            }

            var constructor = type.GetConstructors()
                                                          .OrderBy(x => x.GetParameters().Count())
                                                          .FirstOrDefault();
            var parameterValues = new List<object>();
            var parameters = constructor.GetParameters();
            foreach (var parameter in parameters)
            {
                var parameterValue = CreateInstance(parameter.ParameterType);
                parameterValues.Add(parameterValue);
            }

            var obj = constructor.Invoke(parameterValues.ToArray());

            return obj;
        }
    }
}
