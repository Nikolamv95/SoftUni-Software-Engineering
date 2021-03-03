using System;
using System.Linq;

using Telephony.Contracts;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony.Core
{
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smarthPhone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smarthPhone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer) 
              : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] numberInputs = reader.ReadLine().Split().ToArray();
            string[] sitesInputs = reader.ReadLine().Split().ToArray();
            CallNumbers(numberInputs);
            BrowseUrl(sitesInputs);
        }

        private void BrowseUrl(string[] sitesInputs)
        {
            try
            {
                foreach (var item in sitesInputs)
                {
                    writer.WriteLine(smarthPhone.Browsing(item));
                }
            }
            catch (InvalidUrlException se)
            {

                writer.WriteLine(se.Message);
            }
        }

        private void CallNumbers(string[] numberInputs)
        {
            try
            {
                foreach (var item in numberInputs)
                {
                    if (item.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Calling(item));
                    }
                    else if (item.Length == 10)
                    {
                        writer.WriteLine(smarthPhone.Calling(item));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
            }
            catch (InvalidNumberException se)
            {
                writer.WriteLine(se.Message);
            }
        }
    }
}
