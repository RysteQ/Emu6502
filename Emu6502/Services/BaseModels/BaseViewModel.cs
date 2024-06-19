using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Emu6502.Services.BaseModels;

public class BaseViewModel : INotifyPropertyChanged
{
    public void SetProperty<T>(ref T source, T value, [CallerMemberName] string propertyName = "")
    {
        source = value;
        OnPropertyChanged(propertyName);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));

    private bool _loading;
    public bool Loading
    {
        get => _loading;
        set => SetProperty(ref _loading, value);
    }

    private bool _subordinateLoading;
    public bool SubordinateLoading
    {
        get => _subordinateLoading;
        set => SetProperty(ref _subordinateLoading, value);
    }

    public bool InternalLoading { get; set; }
}