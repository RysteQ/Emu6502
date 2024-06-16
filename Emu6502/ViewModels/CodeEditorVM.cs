using Emu6502.Services.BaseModels;
using System.Windows;
using System.Windows.Input;

namespace Emu6502.ViewModels;

public class CodeEditorVM
{
    public CodeEditorVM()
    {
        CommandTest = new Command(() => Test());
    }

    private void Test()
    {
        MessageBox.Show("f");
    }

    public Command CommandTest { get; set; }
}