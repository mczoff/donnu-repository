using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Abstraction
{
    public interface ICodeLine
    {
        int IndexLine { get; set; }
        IEnumerable<ILexeme> Lexemes { get; set; }
    }
}
