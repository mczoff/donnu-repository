namespace SyntacticAnalysisASM.Core.Abstraction
{
    /// <summary>
    /// Interface provide contract for validation code line
    /// </summary>
    public interface IValidatorLine
    {
        bool Validate(ICodeLine codeLine);
    }
}
