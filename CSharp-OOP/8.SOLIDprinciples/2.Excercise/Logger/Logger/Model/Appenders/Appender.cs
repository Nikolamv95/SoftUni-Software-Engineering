using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Model.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppened;
        protected Appender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return
                    $"Appender type: {this.GetType().Name}, " +
                    $"Layout type: {this.Layout.GetType().Name}, " +
                    $"Report level: {this.Level.ToString()}, " +
                    $"Messages appended: {this.messagesAppened}";
        }
    }
}
