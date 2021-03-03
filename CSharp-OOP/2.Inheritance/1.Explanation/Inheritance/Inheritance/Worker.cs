using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Worker : Person
    {
        public string Company { get; set; }
        public bool IsLazy { get { return true; } }
    }
}
