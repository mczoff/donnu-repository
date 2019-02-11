using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SyntacticAnalysisASM;

namespace SyntacticAnalysisASM.Core.Model
{
    public class AnalizatorLine
        : IAnalizatorLine
    {
        readonly IAnalizatorLexeme _analizatorLexeme;

        public AnalizatorLine()
        {
            _analizatorLexeme = new AnalizatorLexeme();
        }

        public ICodeLine Analize(int index, string line)
            => new CodeLine { IndexLine = index, Lexemes = line.SplitAndKeep(new char[] { ' ', ',' }).Select(t => _analizatorLexeme.Analyze(t)).ToArray() };
    }
}
