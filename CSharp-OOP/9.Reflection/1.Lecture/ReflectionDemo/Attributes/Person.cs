using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    [Author("Person")]
    public class Person
    {
        [Author("Person-Prop")]
        public int Age { get; set; }
    }
}
