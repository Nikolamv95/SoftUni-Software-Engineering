using SolidLogger.Common;
using SolidLogger.Model.Contracts;
using SolidLogger.Model.Enumerations;
using System;
using System.IO;
using System.Linq;

namespace SolidLogger.Model.Files
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.pathManager.CurrentFilePath;

        public long Size => this.CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format, dateTime.ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);

            return formattedMessage;
        }

        private long CalculateFileSize()
        {
            int result = 0;
            string fileText = File.ReadAllText(this.Path);
            return result = fileText.ToCharArray().Where(c=>char.IsLetter(c)).Sum(s => s);
        }
    }
}
