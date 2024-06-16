using System.Windows.Input;

namespace Emu6502.Services.BaseModels;

public class Command : ICommand
{
    public Command(Action action)
    {
        _action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _action.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
    private Action _action;
}