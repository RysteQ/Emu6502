using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Emu6502.Services.BaseModels;

public class BaseUiModel : INotifyPropertyChanged
{
    public void SetProperty<T>(ref T source, T value, [CallerMemberName] string propertyName = "")
    {
        source = value;

        if (ObservingChanges)
            ValueChanged = true;

        OnPropertyChanged(propertyName);
    }

    public void StartObservingForPropertyChanges()
    {
        ObservingChanges = true;
    }

    public void StopObservingForPropertyChanges()
    {
        ObservingChanges = false;
    }

    public bool IsObservingChanges()
    {
        return ObservingChanges;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));

    public bool ValueChanged { get; private set; }
    public bool ObservingChanges { get; private set; }
}