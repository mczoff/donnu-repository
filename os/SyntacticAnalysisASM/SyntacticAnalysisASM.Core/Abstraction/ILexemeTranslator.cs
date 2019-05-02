using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Abstraction
{
    public interface ILexemeTranslator
    {
        ITranslateInfo Translate(IEnumerable<ILexeme> lexemes, IEnumerable<ITranslateCodeLine> identificatorsLines);
    }
}
