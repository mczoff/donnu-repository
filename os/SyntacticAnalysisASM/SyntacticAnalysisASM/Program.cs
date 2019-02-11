using SyntacticAnalysisASM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalysisASM
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SyntacticAnalysisASMContext analysisASMContext = new SyntacticAnalysisASMContext();
            await analysisASMContext.AnalyzeAsync(@"ten db 0ah
                                                    hun dw 100
                                                    ohun db 101
                                                    thous dw 0ff6h
                                                    hund db 78h
                                                    str db 1ah

                                                    mul thous
                                                    mul hun
                                                    mul bx
                                                    mul cx
                                                    mul ax
                                                    pop dx
                                                    pop ds
                                                    pop hun
                                                    mov thous,ax
                                                    mov al,ten
                                                    mov ax,hun
                                                    mov thous,cs
                                                    mov hun,es
                                                    mov ds,hun
                                                    mov bl, ten");
        }
    }
}
