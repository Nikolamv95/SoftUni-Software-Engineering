using Abstraction_Explanation.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction_Explanation
{
    class Microphone : IPrice
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public bool IsDesperatelyNeeded { get; set; }
    }
}
