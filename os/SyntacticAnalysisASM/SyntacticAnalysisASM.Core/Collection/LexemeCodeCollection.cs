using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.Core.Model;
using SyntacticAnalysisASM.Core.Validator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Collection
{
    public class LexemeCodeCollection
        : ReadOnlyCollection<ILexeme>
    {
        static IEnumerable<ILexeme> lexemes = new[]
        {
            new Lexeme { Code = 1, Specification = new StringLexemeSpecification( new [] { "," } )},
            new Lexeme { Code = 2, Specification = new StringLexemeSpecification( new [] { "db" } )},
            new Lexeme { Code = 3, Specification = new StringLexemeSpecification( new [] { "dw" } )},
            new Lexeme { Code = 4, Validation = new MovLexemeValidation(), Specification = new StringLexemeSpecification( new [] { "mov" } )},
            new Lexeme { Code = 5, Validation = new MulLexemeValidation(), Specification = new StringLexemeSpecification( new [] { "mul" } )},
            new Lexeme { Code = 6, Validation = new PopLexemeValidation(), Specification = new StringLexemeSpecification( new [] { "pop" } )},
            new Lexeme { Code = 7, Specification = new StringLexemeSpecification( new [] { "al", "ah", "bl", "cl", "ch", "dl", "dh" })},
            new Lexeme { Code = 8, Specification = new StringLexemeSpecification( new [] { "ax", "bx", "cx", "dx" } )},
            new Lexeme { Code = 9, Specification = new StringLexemeSpecification( new [] { "ds", "ss", "es" } )},
            new Lexeme { Code = 10, Specification = new StringLexemeSpecification( new [] { "cs" } )},
            new Lexeme { Code = 11, Specification = new IntLexemeSpecification() },
            new Lexeme { Code = 12, Validation = new IdentificatorLexemeValidation(), Specification = new IdentificatorLexemeSpecification() }
        };

        public LexemeCodeCollection()
            : base(new List<ILexeme>(lexemes))
        {

        }
    }
}
