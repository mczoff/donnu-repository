namespace SyntacticAnalysisASM.Core.Abstraction
{
    /// <summary>
    /// Interface Lexeme. Сontains code, value and contract validation and specification
    /// </summary>
    public interface ILexeme
    {
        int Code { get; set; }
        ILexemeValidation Validation { get; set; }
        ILexemeSpecification Specification { get; set; }
        ILexemeTranslator Translator { get; set; }
        string Value { get; set; }
    }
}
