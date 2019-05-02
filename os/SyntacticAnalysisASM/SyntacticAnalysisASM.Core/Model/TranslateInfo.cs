using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class TranslateInfo
        : ITranslateInfo
    {
        public int Size { get; set; }
        public string Sourse { get; set; }
    }
}
