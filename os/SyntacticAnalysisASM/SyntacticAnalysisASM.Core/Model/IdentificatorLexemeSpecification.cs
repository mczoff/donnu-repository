using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class IdentificatorLexemeSpecification
        : ILexemeSpecification
    {
        public bool Specificate(string param)
            => true;
    }
}
