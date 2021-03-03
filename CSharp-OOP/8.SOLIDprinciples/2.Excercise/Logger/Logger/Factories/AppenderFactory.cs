using SolidLogger.Common;
using SolidLogger.Model;
using SolidLogger.Model.Appenders;
using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;
using System;

namespace SolidLogger.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        {

        }

        public IAppender CreateAppender(string appenderType, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout , level);
            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.InvalidAppenderTypa);
            }

            return appender;
        }
    }
}
