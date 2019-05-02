using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Collection;
using SyntacticAnalysisASM.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Translator
{
    public class IdentificatorLexemeTranslator
        : ILexemeTranslator
    {
        public ITranslateInfo Translate(IEnumerable<ILexeme> lexemes, IEnumerable<ITranslateCodeLine> identificatorsLines)
        {
            TranslateInfo translateInfo = new TranslateInfo();

            //code db == 2
            if (lexemes.ElementAt(1).Code == 2)
                translateInfo.Size = 1;

            //code dw == 3
            if (lexemes.ElementAt(1).Code == 3)
                translateInfo.Size = 2;

            translateInfo.Sourse = GetHexValue(lexemes);

            return translateInfo;
        }

        private string GetHexValue(IEnumerable<ILexeme> lexemes)
        {
            if (int.TryParse(lexemes.Last().Value, out int resultSourceParse))
                return GetHexSum(lexemes, resultSourceParse);

            try
            {
                int intAgain = int.Parse(lexemes.Last().Value.Trim('h', 'H'), System.Globalization.NumberStyles.HexNumber);
                return GetHexSum(lexemes, intAgain);
            }
            catch
            {

            }

            throw new Exception("Invalid identificator value of lexeme");
        }

        private string GetHexSum(IEnumerable<ILexeme> lexemes, int resultSourceParse)
        {
            if (lexemes.ElementAt(1).Code == 2)
                return resultSourceParse.ToString("X2");

            if (lexemes.ElementAt(1).Code == 3)
                return resultSourceParse.ToString("X4");

            throw new Exception("Invalid lexeme value");
        }
    }
}
