using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode
{
    public interface IFileService
    {
        int MergeTemporaryFiles(string dir);
        int RemoveTemporaryFiles(string dir);
    }
}
