using SyntacticAnalysisASM.Core.Abstraction;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core
{
    public interface ISyntacticAnalysisASMContext
    {
        ICodeLine[] Analyze(string code);
        Task<ICodeLine[]> AnalyzeAsync(string code);

        ITranslateCodeLine[] Translate(string code);
        Task<ITranslateCodeLine[]> TranslateAsync(string code);
    }
}
