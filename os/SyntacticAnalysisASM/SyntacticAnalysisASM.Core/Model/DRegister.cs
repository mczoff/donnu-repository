using SyntacticAnalysisASM.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Models
{
    public class DRegister
        : IDRegister
    {
        public string Name { get; set; }
        public bool? WFlag { get; set; }
        public string Warp { get; set; }
    }
}
