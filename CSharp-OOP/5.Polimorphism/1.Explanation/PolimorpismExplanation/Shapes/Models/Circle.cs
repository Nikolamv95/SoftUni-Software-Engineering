using Shapes.Contracts.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Contracts
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Write positive number");
                }
                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            double result = Math.PI * Math.Pow(this.Radius, 2);
            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = 2 * Math.PI * this.radius;
            return result;
        }
    }
}
