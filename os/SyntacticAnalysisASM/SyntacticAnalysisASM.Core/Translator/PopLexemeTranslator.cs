using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Collection;
using SyntacticAnalysisASM.Core.Collections;
using SyntacticAnalysisASM.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Translator
{
    public class PopLexemeTranslator
        : ILexemeTranslator
    {
        readonly DRegisterCollection _dRegisterCollection;

        public PopLexemeTranslator()
        {
            _dRegisterCollection = new DRegisterCollection();
        }

        public ITranslateInfo Translate(IEnumerable<ILexeme> lexemes, IEnumerable<ITranslateCodeLine> identificatorsLines)
        {
            string hex = default;
            byte size = default;

            var segmentRegister = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.Last().Value.ToLower() && t.WFlag == null);
            var register = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.Last().Value.ToLower() && t.WFlag != null);
            var didentificator = identificatorsLines.FirstOrDefault(t => t.CodeLine.Lexemes.First().Value == lexemes.Last().Value);

            if (segmentRegister != null)
            {
                hex = $"000{segmentRegister.Warp}111".BinaryStringToHexString();
                size = 1;
            }

            if(register != null)
            {
                hex = $"01011{register.Warp}".BinaryStringToHexString();
                size = 1;
            }

            if (didentificator != null)
            {
                size = 4;
                hex = ($"10001111" + $"00000110").BinaryStringToHexString() + didentificator.Address.ToString("X4");
            }

            return new TranslateInfo { Size = size, Sourse = hex };
        }
    }
}
