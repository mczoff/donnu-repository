using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Abstraction
{
    public interface ITranslateCodeLine
    {
        int Address { get; set; }
        ICodeLine CodeLine { get; set; }
        string Source { get; set; }
        int Weight { get; set; }
    }
}
