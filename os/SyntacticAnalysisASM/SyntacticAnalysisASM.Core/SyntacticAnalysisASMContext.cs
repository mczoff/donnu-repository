using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Model;

namespace SyntacticAnalysisASM.Core
{
    public class SyntacticAnalysisASMContext
        : ISyntacticAnalysisASMContext
    {
        readonly IAnalizatorLine _analizatorLine;
        readonly IValidatorLine _validatorLine;

        public SyntacticAnalysisASMContext()
        {
            _analizatorLine = new AnalizatorLine();
            _validatorLine = new ValidatorLine();
        }

        public ICodeLine[] Analyze(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<ICodeLine[]> AnalyzeAsync(string code)
        {
            var lines = code.Split(new[] { "\r\n", }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.TrimStart(' ').TrimEnd(' ')).ToArray();
            var codeLines = lines.Select((t,i) => _analizatorLine.Analize(i,t)).ToArray();

            codeLines.ToList().ForEach(t => t.IsValid = _validatorLine.Validate(t));
            return codeLines;
        }
    }
}
