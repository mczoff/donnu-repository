using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode
{
    public class FileService
        : IFileService
    {
        readonly string _filterExtension = ".tmp";
        readonly string _outputFilename = "/backup.tmp";
        readonly string _errorLogFilename = "/error.log";
        readonly string _removeFilesListFilename = "/ToRemove.txt";

        public int MergeTemporaryFiles(string dir)
        {
            if (!this.ValidationDirectory(dir))
                throw new DirectoryNotFoundException();

            IEnumerable<string> files = this.GetFiterExtensionFiles(Directory.GetFiles(dir));

            if (files.Count() == 0)
                return 0;

            File.WriteAllText(Path.Combine(dir, _outputFilename), this.GenerateOutputFileText(files.Select(t => File.ReadAllText(t))));
            files.ToList().ForEach(t => File.Delete(t));

            return this.GetCountValidFiles(files);
        }

        protected virtual bool ValidationDirectory(string dir)
            => Directory.Exists(dir);

        private int GetCountValidFiles(IEnumerable<string> files)
            => files.Count();

        private string GenerateOutputFileText(IEnumerable<string> fileTexts)
            => fileTexts.Aggregate((t, k) => string.Concat(t, k));

        private IEnumerable<string> GetFiterExtensionFiles(IEnumerable<string> files)
            => files.Where(t => t.EndsWith(_filterExtension));

        public int RemoveTemporaryFiles(string dir)
        {
            if (!this.ValidationDirectory(dir))
                throw new DirectoryNotFoundException();

            IEnumerable<string> files = this.GetFiles(dir);

            long sizeDeletedFiles = default(int);
            files.ToList()
                .ForEach(t =>
                {
                    try
                    {
                        if (!this.ValidationFile(t))
                            throw new FileNotFoundException();

                        sizeDeletedFiles += this.GetSizeInBytes(t);
                    }
                    catch
                    {
                        this.WriteErrorMessageToLog(dir, t);
                    }
                });

            return (int)sizeDeletedFiles;
        }

        protected virtual bool ValidationFile(string filePath)
            => File.Exists(filePath);

        protected virtual IEnumerable<string> GetFiles(string dir)
            => File.ReadAllLines(Path.Combine(dir, _removeFilesListFilename));

        protected virtual void WriteErrorMessageToLog(string dir, string t)
            => File.AppendAllText(Path.Combine(dir, _errorLogFilename), $"Фaйл {Path.GetFileNameWithoutExtension(t)} не был найден.{Environment.NewLine}");

        protected virtual long GetSizeInBytes(string t)
        {
            long sizeDeletedFiles = new FileInfo(t).Length;
            File.Delete(t);

            return sizeDeletedFiles;
        }
    }
}
