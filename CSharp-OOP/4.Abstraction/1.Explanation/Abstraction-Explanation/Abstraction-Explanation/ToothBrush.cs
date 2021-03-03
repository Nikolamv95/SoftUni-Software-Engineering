using Abstraction_Explanation.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction_Explanation
{
    class ToothBrush : IPrice
    {
        public string Model { get; set; }
        // decimal Price { get; set; }
        public int WhiteningEffect  { get; set; }
        public  decimal Price { get; set; }
    }
}
