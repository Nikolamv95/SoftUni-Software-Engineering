using System;
using System.Linq;
using System.Reflection;

using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Core.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == strType);

            if (type == null)
            {
                throw new InvalidOperationException(ExceptionMessages.INV_TYPE);
            }

            object[] ctorParams = new object[] { quantity };
            Food food = (Food)Activator.CreateInstance(type, ctorParams);
            return food;
        }
    }
}
