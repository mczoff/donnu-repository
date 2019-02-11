using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class ValidatorLine 
        : IValidatorLine
    {
        readonly List<ICodeLine> _identificatorLines = new List<ICodeLine>();

        public bool Validate(ICodeLine codeLine)
        {
            if (codeLine.Lexemes.FirstOrDefault()?.Code == 12)
                _identificatorLines.Add(codeLine);

            return codeLine.Lexemes.FirstOrDefault()?.Validation?.Validate(codeLine.Lexemes, _identificatorLines) ?? false; 
        }
    }
}
