using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Abstraction
{
    public interface ILexeme
    {
        int Code { get; set; }
        ILexemeValidation Validation { get; set; }
        ILexemeSpecification Specification { get; set; }
        string Value { get; set; }
        
    }
}
