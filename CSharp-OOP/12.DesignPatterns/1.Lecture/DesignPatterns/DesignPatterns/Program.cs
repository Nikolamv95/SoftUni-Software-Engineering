using SingletonPattern;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerSingleton.Instance.LogToFile();

            //We create the instance by using the instance propperty (get;)
            var logger = LoggerSingleton.Instance;
            //Then we can use its functions
            logger.LogToFile();
        }
    }
}
 