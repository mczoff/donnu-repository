using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Validator
{
    public class MovLexemeValidation
        : ILexemeValidation
    {
        public bool Validate(IEnumerable<ILexeme> lexemes, IEnumerable<ICodeLine> identificatorsLines)
        {
            if (lexemes.Count() != 4)
                return false;

            if (lexemes.ElementAtOrDefault(2).Code != 1)
                return false;

            bool is3Word = false;
            bool is3Byte = false;
            bool is1Word = false;
            bool is1Byte = false;


            if (lexemes.ElementAtOrDefault(3).Code == 12)
            {
                var identificator3Line = identificatorsLines.FirstOrDefault(t => t.Lexemes.First().Value == lexemes.ElementAtOrDefault(3)?.Value);

                if (identificator3Line == null)
                    return false;

                is3Word = new WordLexemeValidation().Validate(identificator3Line.Lexemes, null);
                is3Byte = new ByteLexemeValidator().Validate(identificator3Line.Lexemes, null);

            }
            if (lexemes.ElementAtOrDefault(1)?.Code == 12)
            {
                var identificator1Line = identificatorsLines.FirstOrDefault(t => t.Lexemes.First().Value == lexemes.ElementAtOrDefault(1)?.Value);

                if (identificator1Line == null)
                    return false;

                is1Word = new WordLexemeValidation().Validate(identificator1Line.Lexemes, null);
                is1Byte = new ByteLexemeValidator().Validate(identificator1Line.Lexemes, null);
            }


            if (lexemes.ElementAtOrDefault(1).Code == 8)
            {
                if (lexemes.ElementAtOrDefault(3)?.Code == 9)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 12 && is3Word)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 8)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 11 && new WordNumberValidator().Validate(new[] { lexemes.ElementAtOrDefault(3) }, null))
                    return true;
            }

            if (lexemes.ElementAtOrDefault(1)?.Code == 7)
            {
                if (lexemes.ElementAtOrDefault(3)?.Code == 7)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 12 && is3Byte)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 11 && new ByteNumberValidator().Validate(new[] { lexemes.ElementAtOrDefault(3) }, null))
                    return true;
            }

            if (lexemes.ElementAtOrDefault(1)?.Code == 9)
            {
                if (lexemes.ElementAtOrDefault(3)?.Code == 12 && is3Word)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 8)
                    return true;
            }

            if (lexemes.ElementAtOrDefault(1)?.Code == 12 && is1Word)
            {
                if (lexemes.ElementAtOrDefault(3)?.Code >= 8 && lexemes.ElementAtOrDefault(3)?.Code <= 10)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 11 && new WordNumberValidator().Validate(new[] { lexemes.ElementAtOrDefault(3) }, null))
                    return true;
            }

            if (lexemes.ElementAtOrDefault(1)?.Code == 12 && is1Byte)
            {
                if (lexemes.ElementAtOrDefault(3)?.Code == 7)
                    return true;

                if (lexemes.ElementAtOrDefault(3)?.Code == 11 && new ByteNumberValidator().Validate(new[] { lexemes.ElementAtOrDefault(3) }, null))
                    return true;
            }

            return false;
        }
    }
}
