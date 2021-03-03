using System;
using System.Globalization;
using System.Linq;

using SOLID_Logger.Model.Core.Contracts;
using SolidLogger.Common;
using SolidLogger.IOManagement.Contracts;
using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;
using SolidLogger.Model.Errors;


namespace SOLID_Logger.Model
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;


        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "END")
            {
                string[] errorArg = command.Split('|').ToArray();
                string levelStr = errorArg[0];
                string dataTimeStr = errorArg[1];
                string message = errorArg[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);


                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact(dataTimeStr,
                                        GlobalConstants.DateTimeFormat,
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidDateTimeFormat);
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);
            }
            this.writer.WriteLine(this.logger.ToString());
        }
    }
}
