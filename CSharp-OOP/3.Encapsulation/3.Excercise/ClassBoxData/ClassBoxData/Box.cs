using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string INVALID_SIDE_EXC_MSG = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValudateSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValudateSide(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValudateSide(value, nameof(Height));
                this.height = value;
            }
        }

        public double CalculateVolume() => this.Length * this.Width * this.Height;
        public double CalculateLateralSurfaceArea() => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        public double CalculateSurfaceArea() => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {CalculateVolume():f2}");
            return sb.ToString().TrimEnd();
        }
        private void ValudateSide(double value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE_EXC_MSG, paramName));
            }
        }
    }
}
