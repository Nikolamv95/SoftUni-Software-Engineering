using SolidLogger.IOManagement;
using SolidLogger.IOManagement.Contracts;
using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;

namespace SolidLogger.Model.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;
        public FileAppender(ILayout layout, Level level, IFile loggfile) : base(layout, level)
        {
            this.File = loggfile;
            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);
            this.writer.WriteLine(formattedMessage);
            this.messagesAppened++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}"; 
        }

    }
}
