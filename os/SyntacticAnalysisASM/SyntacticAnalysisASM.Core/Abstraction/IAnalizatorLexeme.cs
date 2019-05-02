namespace SyntacticAnalysisASM.Core.Abstraction
{
    /// <summary>
    /// Inteface provide contract for analize code specification (0 - mov and ect).
    /// </summary>
    public interface IAnalizatorLexeme
    {
        ILexeme Analyze(string spec);
    }
}
