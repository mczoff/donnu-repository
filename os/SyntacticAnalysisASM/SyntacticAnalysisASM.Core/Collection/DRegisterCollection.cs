using SyntacticAnalysisASM.Core.Abstractions;
using SyntacticAnalysisASM.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Collections
{
    public class DRegisterCollection
        : ReadOnlyCollection<IDRegister>
    {
        static IEnumerable<IDRegister> _dRegisters = new[]
        {
           new DRegister { Name = "al", Warp = "000", WFlag = false },
           new DRegister { Name = "cl", Warp = "001", WFlag = false },
           new DRegister { Name = "dl", Warp = "010", WFlag = false },
           new DRegister { Name = "bl", Warp = "011", WFlag = false },
           new DRegister { Name = "ah", Warp = "100", WFlag = false },
           new DRegister { Name = "ch", Warp = "101", WFlag = false },
           new DRegister { Name = "dh", Warp = "110", WFlag = false },
           new DRegister { Name = "bh", Warp = "111", WFlag = false },
           new DRegister { Name = "ax", Warp = "000", WFlag = true },
           new DRegister { Name = "cx", Warp = "001", WFlag = true },
           new DRegister { Name = "dx", Warp = "010", WFlag = true },
           new DRegister { Name = "bx", Warp = "011", WFlag = true },
           new DRegister { Name = "sp", Warp = "100", WFlag = true },
           new DRegister { Name = "bp", Warp = "101", WFlag = true },
           new DRegister { Name = "si", Warp = "110", WFlag = true },
           new DRegister { Name = "di", Warp = "111", WFlag = true },
           new DRegister { Name = "es", Warp = "00" },
           new DRegister { Name = "cs", Warp = "01" },
           new DRegister { Name = "ss", Warp = "10" },
           new DRegister { Name = "ds", Warp = "11" }
        };

        public DRegisterCollection() 
            : base(_dRegisters.ToList())
        {
        }
    }
}
