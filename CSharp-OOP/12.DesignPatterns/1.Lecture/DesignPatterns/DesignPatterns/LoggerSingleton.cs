using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{
    //We use it if we want to create one global object which will be created only one time
    public sealed class LoggerSingleton
    {
        private static LoggerSingleton instance;
        private static object someLock = new object();

        //The constructor is always private
        private LoggerSingleton()
        {

        }

        public static LoggerSingleton Instance
        {
            get
            {   //This if statement can be checked by multiple threads (multithreaded programming)
                if (instance == null)
                {
                    //Next step is to pass the first thread and lock all the rest before the operation is done
                    lock (someLock)
                    {
                        //After that the first thread which pass the lock will create the object, but the rest
                        //of the threads will not be able to create it because the instance is already created
                        if (instance == null)
                        {
                            instance = new LoggerSingleton();
                        }
                    }
                }
                //and the next threads will return the object which is already created
                return instance;
            }
        }

        public void LogToFile()
        {
            Console.WriteLine("Logged to file");
        }
    }

}
