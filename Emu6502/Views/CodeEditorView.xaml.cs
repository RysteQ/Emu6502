using Emu6502.ViewModels;
using System.Windows;

namespace Emu6502.Views;

public partial class CodeEditorView : Window
{
    public CodeEditorView()
    {
        InitializeComponent();

        _viewModel = new();
        DataContext = _viewModel;
    }

    private CodeEditorVM _viewModel;
}