using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Validator
{
    public class IdentificatorLexemeValidation
        : ILexemeValidation
    {
        public bool Validate(IEnumerable<ILexeme> lexemes, IEnumerable<ICodeLine> identificatorsLines)
        {
            if(lexemes.ElementAtOrDefault(1)?.Code == 2)
            {
                if (lexemes.ElementAtOrDefault(2)?.Code == 11 && new ByteNumberValidator().Validate(new[] { lexemes.ElementAtOrDefault(2) }, null))
                    return true;
            }

            if (lexemes.ElementAtOrDefault(1)?.Code == 3)
            {
                if (lexemes.ElementAtOrDefault(2)?.Code == 11 && new WordNumberValidator().Validate(new[] { lexemes.ElementAtOrDefault(2) }, null))
                    return true;
            }

            return false;
        }
    }
}
