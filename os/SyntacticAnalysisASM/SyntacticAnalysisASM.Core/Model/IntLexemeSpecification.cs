using SyntacticAnalysisASM.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM.Core.Model
{
    public class IntLexemeSpecification
        : ILexemeSpecification
    {
        public bool Specificate(string param)
        {
            try
            {
                if (param.Last() == 'h')
                {
                    int.Parse(param.TrimEnd('h'), NumberStyles.AllowHexSpecifier);
                    return true;
                }

                //TODO: BINARY 

                int.Parse(param, NumberStyles.Integer);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
