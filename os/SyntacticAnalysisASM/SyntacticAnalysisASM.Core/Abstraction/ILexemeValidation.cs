using System.Collections.Generic;

/// <summary>
/// Interface provide contract for validation enumerable lexeme
/// </summary>
namespace SyntacticAnalysisASM.Core.Abstraction
{
    public interface ILexemeValidation
    {
        bool Validate(IEnumerable<ILexeme> lexemes, IEnumerable<ICodeLine> identificatorsLines);
    }
}
