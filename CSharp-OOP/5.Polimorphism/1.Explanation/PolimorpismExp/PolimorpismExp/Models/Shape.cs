using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Contracts.BaseClass
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.CalculatePerimeter().ToString());
            sb.Append(this.CalculateArea().ToString());
            return sb.ToString();
        }
    }
}
