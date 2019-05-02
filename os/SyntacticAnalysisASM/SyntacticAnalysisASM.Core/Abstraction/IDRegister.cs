using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Abstractions
{
    public interface IDRegister
    {
        string Name { get; set; }
        bool? WFlag { get; set; }
        string Warp { get; set; }
    }
}
