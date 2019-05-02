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
    public class MovLexemeTranlator
        : ILexemeTranslator
    {
        readonly DRegisterCollection _dRegisterCollection;

        public MovLexemeTranlator()
        {
            _dRegisterCollection = new DRegisterCollection();
        }

        //|100010dw|modregr/m|

        public ITranslateInfo Translate(IEnumerable<ILexeme> lexemes, IEnumerable<ITranslateCodeLine> identificatorsLines)
        {
            string hex = default;
            byte size = default;

            //register on first place
            if(_dRegisterCollection.Any(t => t.Name == lexemes.ElementAt(1).Value && t.WFlag != null))
            {
               
                var register = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.ElementAt(1).Value && t.WFlag != null);
                var didentificator = identificatorsLines.FirstOrDefault(t => t.CodeLine.Lexemes.First().Value == lexemes.ElementAt(3).Value);

                if (register.Name == "al" || register.Name == "ax")
                {
                    hex = ($"1010000{(register.WFlag.Value ? '1' : '0')}").BinaryStringToHexString() + didentificator.Address.ToString("X4");
                    size = 3;
                }
                else
                {
                    hex = ($"1000100{(register.WFlag.Value ? '1' : '0')}" + $"00{register.Warp}110").BinaryStringToHexString();
                    size = 3;
                }
            }

            //register on third place
            if (_dRegisterCollection.Any(t => t.Name == lexemes.ElementAt(3).Value && t.WFlag != null))
            {
                var register = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.ElementAt(3).Value && t.WFlag != null);
                var didentificator = identificatorsLines.FirstOrDefault(t => t.CodeLine.Lexemes.First().Value == lexemes.ElementAt(1).Value);

                if (register.Name == "al" || register.Name == "ax")
                {
                    hex = ($"1010001{(register.WFlag.Value ? '1' : '0')}").BinaryStringToHexString() + didentificator.Address.ToString("X4");
                    size = 3;
                }
                else
                {
                    hex = ($"1000101{(register.WFlag.Value ? '1' : '0')}" + $"00{register.Warp}110").BinaryStringToHexString();
                    size = 3;
                }  
            }

            //segment on first place
            if (_dRegisterCollection.Any(t => t.Name == lexemes.ElementAt(1).Value && t.WFlag == null))
            {
                var register = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.ElementAt(1).Value && t.WFlag == null);
                var didentificator = identificatorsLines.FirstOrDefault(t => t.CodeLine.Lexemes.First().Value == lexemes.ElementAt(3).Value);

                hex = ($"10001110"+ $"000{register.Warp}110").BinaryStringToHexString() + didentificator.Address.ToString("X4");
                size = 4;
            }

            //segment on third place
            if (_dRegisterCollection.Any(t => t.Name == lexemes.ElementAt(3).Value && t.WFlag == null))
            {
                var register = _dRegisterCollection.FirstOrDefault(t => t.Name == lexemes.ElementAt(3).Value && t.WFlag == null);
                var didentificator = identificatorsLines.FirstOrDefault(t => t.CodeLine.Lexemes.First().Value == lexemes.ElementAt(1).Value);

                hex = ($"10001100" + $"000{register.Warp}110").BinaryStringToHexString() + didentificator.Address.ToString("X4");
                size = 4;
            }

            return new TranslateInfo { Size = size, Sourse = hex };
        }
    }
}
