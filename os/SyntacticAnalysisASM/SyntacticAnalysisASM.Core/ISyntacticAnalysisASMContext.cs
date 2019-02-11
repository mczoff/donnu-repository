using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core
{
    public interface ISyntacticAnalysisASMContext
    {
        ICodeLine[] Analyze(string code);
        Task<ICodeLine[]> AnalyzeAsync(string code);
    }
}
