using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Validator
{
    public class MulLexemeValidation
        : ILexemeValidation
    {
        public bool Validate(IEnumerable<ILexeme> lexemes, IEnumerable<ICodeLine> identificatorsLines)
        {
            if (lexemes.ElementAtOrDefault(1)?.Code >= 7 && lexemes.ElementAtOrDefault(1)?.Code <= 8)
                return true;

            if(lexemes.ElementAtOrDefault(1)?.Code == 12)
            {
                var identificatorLine = identificatorsLines.FirstOrDefault(t => t.Lexemes.First().Value == lexemes.ElementAt(1).Value);

                if (identificatorLine == null)
                    return false;

                bool isWord = new WordLexemeValidation().Validate(identificatorLine.Lexemes, null);

                return isWord;
            }

            return false;
        }
    }
}
