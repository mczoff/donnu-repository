namespace SyntacticAnalysisASM.Core.Abstraction
{
    /// <summary>
    /// Interface provide contract for specification lexeme, check byte\work and variables names
    /// </summary>
    public interface ILexemeSpecification
    {
        bool Specificate(string param);
    }
}
