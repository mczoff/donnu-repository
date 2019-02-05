using ProductionCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode2.Tests.Fakes
{
    public class FakeStubFileService
        : IFileService
    {
        public int ReturnValueMergeTemporaryFiles { get; set; }
        public int ReturnValueRemoveTemporaryFiles { get; set; }

        public int MergeTemporaryFiles(string dir)
            => this.ReturnValueMergeTemporaryFiles;
        
        public int RemoveTemporaryFiles(string dir)
            => this.ReturnValueRemoveTemporaryFiles;
    }
}
