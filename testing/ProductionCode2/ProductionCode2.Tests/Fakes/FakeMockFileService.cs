using ProductionCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode2.Tests.Fakes
{
    public class FakeMockFileService
        : IFileService
    {
        public int MergeTemporaryFilesIsCalledCount { get; set; }
        public int RemoveTemporaryFilesIsCalledCount { get; set; }

        public int MergeTemporaryFiles(string dir)
        {
            MergeTemporaryFilesIsCalledCount++;

            return 0;
        }

        public int RemoveTemporaryFiles(string dir)
        {
            RemoveTemporaryFilesIsCalledCount++;

            return 0;
        }
    }
}
