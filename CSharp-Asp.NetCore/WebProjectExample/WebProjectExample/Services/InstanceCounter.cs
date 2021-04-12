using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectExample.Services
{
    public class InstanceCounter : IInstanceCounter
    {
        private static int instances;

        public InstanceCounter()
        {
            instances++;
        }

        public int Instances => instances;
    }
}

