using SyntacticAnalysisASM.Core;
using SyntacticAnalysisASM.Core.Abstraction;
using SyntacticAnalysisASM.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SyntacticAnalysisASM.Client
{
    public class MainWindowViewModel
        : BindableBase
    {
        string _programmText = @"ten db 0ah
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
mov bl, ten";

        public string ProgrammText
        {
            get => _programmText;
            set => this.SetProperty(ref this._programmText, value);
        }

        string _errorText = string.Empty;
        public string ErrorText
        {
            get => _errorText;
            set => this.SetProperty(ref this._errorText, value);
        }

        ICommand _exitWindow;
        public ICommand ExitWindow
                => _exitWindow ?? (_exitWindow = new RelayCommand(
                        window =>
                        {
                            (window as Window).Close();
                        }));

        ICommand _analyzeCodeCommand;
        public ICommand AnalyzeCodeCommand
                => _analyzeCodeCommand ?? (_analyzeCodeCommand = new RelayCommand(
                        async _ =>
                        {
                            SyntacticAnalysisASMContext analysisASMContext = new SyntacticAnalysisASMContext();

                            ICodeLine[] codeLine = await analysisASMContext.AnalyzeAsync(_programmText);

                            this.ErrorText = string.Empty;

                            foreach (var line in codeLine)
                                ErrorText += $"Line {line.IndexLine + 1} - {line.IsValid} {Environment.NewLine}";
                        }));
    }
}
