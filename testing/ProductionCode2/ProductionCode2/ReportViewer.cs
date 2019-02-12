using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode
{
    public class ReportViewer
        : IReportViewer
    {
        public int? BlockCount { get; set; }
        public int? UsedSize { get; set; }

        public IFileService FileService { get; set; }

        public ReportViewer()
        {

        }

        public ReportViewer(IFileService fileService)
        {
            FileService = fileService;
        }
        
        public void PrepareData(string dir)
        {
            int countLocalFiles = this.FileService.MergeTemporaryFiles(dir);

            if (countLocalFiles == 0)
                return;

            BlockCount = countLocalFiles;
        }

        public void Clean(string dir)
        {
            try
            {
                int userSize = this.FileService.RemoveTemporaryFiles(dir);
                this.UsedSize = userSize;
            }
            catch
            {

            }
        }
    }
}
