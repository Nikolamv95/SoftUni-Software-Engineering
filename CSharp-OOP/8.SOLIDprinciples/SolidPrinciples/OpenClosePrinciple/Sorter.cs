using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenClosePrinciple
{
    public class Sorter
    {
        private List<ISortingStrategy> strategies;

        public Sorter()
        {
            this.strategies = new List<ISortingStrategy>()
            {
                new MergeSorter(),
                new SelectionSorter(),
                new QuickSorter(),
            };
        }


        public ICollection<int> Sort(ICollection<int> collection, string algorithm)
        {
            //We can use reflection or simple Listr<string(sorting names strategies)>()

            var sortedType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ISortingStrategy)
                .IsAssignableFrom(t) && t.IsClass).FirstOrDefault(t => t.Name.ToLower() == algorithm);

            //Type sortedType = (Type)this.strategies.Single(t => t.ToString() == algorithm);
            ISortingStrategy strategy = (ISortingStrategy)Activator.CreateInstance(sortedType);

            return strategy.Sort(collection);
        }
    }
}

