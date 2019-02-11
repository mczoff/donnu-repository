﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SyntacticAnalysisASM.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            code_textEditor.Text = (this.DataContext as MainWindowViewModel).ProgrammText;
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            (this.DataContext as MainWindowViewModel).ProgrammText = code_textEditor.Text;
        }
    }
}
