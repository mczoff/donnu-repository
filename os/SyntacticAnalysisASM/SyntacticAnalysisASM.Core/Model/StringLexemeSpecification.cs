using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class StringLexemeSpecification
        : ILexemeSpecification
    {
        readonly string[] _values;

        public StringLexemeSpecification(IEnumerable<string> values)
        {
            _values = values?.ToArray();
        }

        public bool Specificate(string param)
            => _values.Contains(param);
    }
}
