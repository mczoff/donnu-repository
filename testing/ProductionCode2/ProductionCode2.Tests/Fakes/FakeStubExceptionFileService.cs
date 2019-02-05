using ProductionCode;
using System;
using System.IO;

namespace ProductionCode2.Tests.Fakes
{
    public class FakeStubExceptionFileService
        : IFileService
    {
        public Exception ExceptionRemoveTemporaryFiles { get; set; }
        public Exception ExceptionMergeTemporaryFiles { get; set; }

        public int MergeTemporaryFiles(string dir)
        {
            throw ExceptionMergeTemporaryFiles;
        }

        public int RemoveTemporaryFiles(string dir)
        {
            throw ExceptionRemoveTemporaryFiles;
        }
    }
}