using System.Collections.Generic;

namespace SyntacticAnalysisASM.Core.Abstraction
{
    /// <summary>
    /// Interface provide contract for code line which was recognized, but havent validate
    /// </summary>
    public interface ICodeLine
    {
        int IndexLine { get; set; }
        bool IsValid { get; set; }
        IEnumerable<ILexeme> Lexemes { get; set; }
    }
}
