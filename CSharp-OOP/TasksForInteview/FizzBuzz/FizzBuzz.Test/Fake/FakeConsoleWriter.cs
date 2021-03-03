using FizzBuzz.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Test.Fake
{
    public class FakeConsoleWriter : IWriter
    {
        public string Result { get; set; }

        public void Write(string text)
        {
            this.Result += text;
        }

        public void WriteLine(string text)
        {
            this.Result += text;
        }
    }
}
