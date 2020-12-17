    using System;
using System.Dynamic;
using System.Net.WebSockets;
    using System.Threading.Tasks.Dataflow;

    namespace FirstProjectInPrograming

{
    class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double centimaters = inches * 2.54;
            Console.WriteLine(centimaters);
        }

    }
}