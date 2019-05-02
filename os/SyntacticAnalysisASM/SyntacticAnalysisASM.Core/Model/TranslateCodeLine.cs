using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class TranslateCodeLine
        : ITranslateCodeLine
    {
        public int Address { get; set; }
        public ICodeLine CodeLine { get; set; }
        public string Source { get; set; }
        public int Weight { get; set; }
    }
}
