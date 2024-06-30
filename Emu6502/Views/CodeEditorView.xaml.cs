using Emu6502.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Emu6502.Views;

public partial class CodeEditorView : Window
{
    public CodeEditorView()
    {
        InitializeComponent();

        _viewModel = new();
        DataContext = _viewModel;
    }

    private void TextBoxCodeEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;

        LabelRowCount.Content = $"Row: {textBox.Text.Take(textBox.CaretIndex).Count(selectedChar => selectedChar == '\n') + 1}";
        LabelColumnCount.Content = $"Col: {textBox.Text.Split('\n')[textBox.Text.Take(textBox.CaretIndex).Count(selectedChar => selectedChar == '\n')].Length + 1}";
    }

    private CodeEditorVM _viewModel;
}