using System;
using System.Collections.Generic;
using System.Linq;

using SOLID_Logger.Model;
using SOLID_Logger.Model.Core.Contracts;
using SolidLogger.Common;
using SolidLogger.Factories;
using SolidLogger.IOManagement;
using SolidLogger.IOManagement.Contracts;
using SolidLogger.Model;
using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;
using SolidLogger.Model.Files;
using SolidLogger.Model.PathManagement;

namespace SolidLogger
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs","logs.txt");
            IFile file = new LogFile(pathManager);
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            ILogger logger = SetUpLogger(n, reader, writer, file, layoutFactory, appenderFactory);
            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger SetUpLogger(int appendersCnt, IReader reader, IWriter writer, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCnt; i++)
            {
                string[] appendersArg = reader.ReadLine().Split().ToArray();

                string appenderType = appendersArg[0];
                string layoutType = appendersArg[1];

                bool hasError = false;
                Level level = ParsedLevel(appendersArg, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, level, file);

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }

        private static Level ParsedLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {

            Level appenderLevel = Level.INFO;

            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidLevelType);
                    hasError = true;
                }

                appenderLevel = (Level)enumParsed;
            }

            return appenderLevel;
        }
    }
}
