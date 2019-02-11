using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class CodeLine
        : ICodeLine
    {
        public int IndexLine { get; set; }
        public IEnumerable<ILexeme> Lexemes { get; set; }
        public bool IsValid { get; set; }
    }
}
