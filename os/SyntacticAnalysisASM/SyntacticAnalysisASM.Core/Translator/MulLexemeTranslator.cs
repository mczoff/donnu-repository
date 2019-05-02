using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Collections;
using SyntacticAnalysisASM.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Translator
{
    public class MulLexemeTranslator
        : ILexemeTranslator
    {
        readonly DRegisterCollection _dRegisterCollection;

        public MulLexemeTranslator()
        {
            _dRegisterCollection = new DRegisterCollection();
        }

        public ITranslateInfo Translate(IEnumerable<ILexeme> lexemes, IEnumerable<ITranslateCodeLine> identificatorsLines)
        {
            string hex = default;
            byte size = default;

            var dregister = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.Last().Value);
            var didentificator = identificatorsLines.FirstOrDefault(t => t.CodeLine.Lexemes.First().Value == lexemes.Last().Value);

            if (dregister != null)
            {
                if(dregister.WFlag == null)
                    throw new Exception("W flag was null");

                size = 2;
                hex = ($"1111011{(dregister.WFlag.Value ? '1' : '0')}11100{dregister.Warp}").BinaryStringToHexString();
            }
                
            if (didentificator != null)
            {
                size = 4;
                hex = ($"1111011{(didentificator.Weight == 1 ? '0' : '1')}00100110").BinaryStringToHexString() + didentificator.Address.ToString("X4");
            }
                
            return new TranslateInfo { Size = size, Sourse = hex };
        }
    }
}
