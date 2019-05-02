using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class Lexeme
        : ILexeme
    {
        public int Code { get; set; }
        public ILexemeValidation Validation { get; set; }
        public ILexemeSpecification Specification { get; set; }
        public ILexemeTranslator Translator { get; set; }
        public string Value { get; set; }
    }
}
