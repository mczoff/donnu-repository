namespace SyntacticAnalysisASM.Core.Abstraction
{
    /// <summary>
    /// Interface provide contract for analize code line
    /// </summary>
    public interface IAnalizatorLine
    {
        ICodeLine Analize(int index, string line);
    }
}
