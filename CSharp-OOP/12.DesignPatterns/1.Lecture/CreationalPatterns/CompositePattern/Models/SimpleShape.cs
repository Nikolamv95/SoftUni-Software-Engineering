using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class SimpleShape : IDrawable
    {
        public SimpleShape(string name)
        {
            this.Name = name;
        }

        public string Name { get; set ; }

        public void AddChild(IDrawable child)
        {
            throw new ArgumentException();
        }

        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(this.Name);
        }
    }
}
