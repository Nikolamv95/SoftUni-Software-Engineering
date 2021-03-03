using SolidLogger.Common;
using SolidLogger.IOManagement;
using SolidLogger.IOManagement.Contracts;
using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Model.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            :base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = string.Format(format, 
                                                    dateTime.ToString(GlobalConstants.DateTimeFormat),
                                                    level.ToString(), 
                                                    message);

            this.writer.WriteLine(formattedString);
            this.messagesAppened++;
        }
    }
}
