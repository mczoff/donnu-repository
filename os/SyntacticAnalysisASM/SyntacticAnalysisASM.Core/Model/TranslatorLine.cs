using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class TranslatorLine
        : ITranslatorLine
    {
        readonly IList<ITranslateCodeLine> _tranlateCodeLines;

        int _currentAddress = 0;
        
        public TranslatorLine()
        {
            _tranlateCodeLines = new List<ITranslateCodeLine>();
        }

        public ITranslateCodeLine Translate(ICodeLine codeLine)
        {
            var translateInfo = codeLine.Lexemes.First().Translator.Translate(codeLine.Lexemes, _tranlateCodeLines);

            var tcodeline = new TranslateCodeLine { Weight = translateInfo.Size, Source = translateInfo.Sourse, Address = _currentAddress, CodeLine = codeLine };

            _currentAddress += translateInfo.Size;

            _tranlateCodeLines.Add(tcodeline);

            return tcodeline;
        }

        private bool IsLexemeVariable(ILexeme lexeme)
            => _tranlateCodeLines.Any(t => t.CodeLine.Lexemes.ElementAt(0).Value == lexeme.Value);
    }
}
