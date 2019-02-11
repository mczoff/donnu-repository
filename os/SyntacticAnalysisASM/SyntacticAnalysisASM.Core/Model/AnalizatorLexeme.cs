using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class AnalizatorLexeme
        : IAnalizatorLexeme
    {
        readonly LexemeCodeCollection _lexemeCodeCollection;

        public AnalizatorLexeme()
        {
            _lexemeCodeCollection = new LexemeCodeCollection();
        }

        public ILexeme Analyze(string spec)
        {
            for (int i = 0; i < _lexemeCodeCollection.Count; i++)
            {
                if (_lexemeCodeCollection[i].Specification.Specificate(spec))
                    return new Lexeme { Code = _lexemeCodeCollection[i].Code, Validation = _lexemeCodeCollection[i].Validation, Specification = _lexemeCodeCollection[i].Specification, Value = spec };
            }

            throw new NotSupportedException($"Lexeme with {spec} not found");
        }
    }
}
