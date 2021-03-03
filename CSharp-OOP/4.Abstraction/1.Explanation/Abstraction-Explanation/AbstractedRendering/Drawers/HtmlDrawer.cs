using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractedRendering.Drawers
{
    class HtmlDrawer : IDrawer
    {
        private string path;
        private StringBuilder result;

        public HtmlDrawer(string path)
        {
            this.path = path;
            this.result = new StringBuilder();
        }

        public void Write(string input)
        {
            result.Append(input);
            using (StreamWriter writer = new StreamWriter(path + ".html", false))
            {
                writer.Write($"<html><head></head><body><h1>BestGame!!!</h1><p>${result.ToString()}</p></body><html>");
            }
        }

        public void WriteLine(string input)
        {
            result.Append(input);
            using (StreamWriter writer = new StreamWriter(path + ".html", false))
            {
                writer.Write($"<html><head></head><body><h1>BestGame!!!</h1><p>${result.ToString()}</p></body><html>");
            };
        }
    }
}
