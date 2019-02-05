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
        readonly string _removeFilesListFilename = "/error.log";

        public int MergeTemporaryFiles(string dir)
        {
            IEnumerable<string> files = Directory.GetFiles(dir).Where(t => t.EndsWith(_filterExtension));

            if (files.Count() == 0)
                return 0;

            File.WriteAllText(Path.Combine(dir, _outputFilename), files.Aggregate((t,k) => string.Concat(t,k)));
            files.ToList().ForEach(t => File.Delete(t));

            return files.Count();
        }

        public int RemoveTemporaryFiles(string dir)
        {
            IEnumerable<string> files = File.ReadAllLines(Path.Combine(dir, _removeFilesListFilename));

            long sizeDeletedFiles = default(int);
            files.ToList()
                .ForEach(t => 
                {
                    try
                    {
                        sizeDeletedFiles =+ new FileInfo(t).Length;
                        File.Delete(t);
                    }
                    catch
                    {
                        File.AppendAllText(Path.Combine(dir, _errorLogFilename), $"Фaйл {Path.GetFileNameWithoutExtension(t)} не был найден.{Environment.NewLine}");
                    }
                });

            return (int)sizeDeletedFiles;
        }
    }
}
