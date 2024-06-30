using Emu6502.Services.BaseModels;
using System.Windows.Media;

namespace Emu6502.Models.CodeEditor;

public class FontUi : BaseUiModel
{
    private double _size = 10;
    public double Size
    {
        get => _size;
        set => SetProperty(ref _size, value);
    }

    private FontFamily _font = new("Courier");
    public FontFamily Font
    {
        get => _font;
        set => SetProperty(ref _font, value);
    }
}