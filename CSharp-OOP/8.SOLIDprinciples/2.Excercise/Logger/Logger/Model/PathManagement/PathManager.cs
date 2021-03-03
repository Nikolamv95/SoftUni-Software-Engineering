using SolidLogger.Model.Contracts;
using System;
using System.IO;

namespace SolidLogger.Model.PathManagement
{
    public class PathManager : IPathManager
    {
        //private const string PATH_DELIMITER = "\\";

        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        //Tells me the path where my app is running on user PC
        private PathManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        //They should pass folder name and file name
        public PathManager(string folderName, string fileName) 
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }


        public string CurrentDirectoryPath
            => Path.Combine(this.currentPath, this.folderName);

        public string CurrentFilePath
            => Path.Combine(this.CurrentDirectoryPath, this.fileName);

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
