using Emu6502.Models.CodeEditorModels;
using Emu6502.Services.BaseModels;
using System.Collections.ObjectModel;

namespace Emu6502.ViewModels;

public class FontDialogVM : BaseViewModel
{
    public FontDialogVM()
    {
        CommandIncreaseFontSize = new(IncreaseFontSize);
        CommandDecreaseFontSize = new(DecreaseFontSize);

        SelectedFont = Fonts.First();
    }

    public FontDialogVM(string defaultFontFamily = "Courier", int defaultFontSize = 10)
    {
        CommandIncreaseFontSize = new(IncreaseFontSize);
        CommandDecreaseFontSize = new(DecreaseFontSize);

        FontUi? selectedDefaultFont = Fonts.FirstOrDefault(selectedFont => selectedFont.Font.Source == defaultFontFamily);

        foreach (FontUi font in Fonts)
        {
            font.Size = defaultFontSize;
        }

        if (selectedDefaultFont != null)
        {
            SelectedFont = selectedDefaultFont;
        }
    }

    private void IncreaseFontSize()
    {
        SelectedFont.Size++;
    }

    private void DecreaseFontSize()
    {
        SelectedFont.Size--;
    }

    public Command CommandIncreaseFontSize { get; init; }
    public Command CommandDecreaseFontSize { get; init; }

    private FontUi _selectedFont = new();
    public FontUi SelectedFont
    {
        get => _selectedFont;
        set => SetProperty(ref _selectedFont, value);
    }

    public ObservableCollection<FontUi> Fonts { get; init; } =
    [
        new() { Font = new("Arial"), Size = 10 },
        new() { Font = new("Arial Black"), Size = 10 },
        new() { Font = new("Bahnschrift"), Size = 10 },
        new() { Font = new("Calibri"), Size = 10 },
        new() { Font = new("Cambria"), Size = 10 },
        new() { Font = new("Cambria Math"), Size = 10 },
        new() { Font = new("Candara"), Size = 10 },
        new() { Font = new("Comic Sans MS"), Size = 10 },
        new() { Font = new("Consolas"), Size = 10 },
        new() { Font = new("Constantia"), Size = 10 },
        new() { Font = new("Corbel"), Size = 10 },
        new() { Font = new("Courier New"), Size = 10 },
        new() { Font = new("Ebrima"), Size = 10 },
        new() { Font = new("Franklin Gothic Medium"), Size = 10 },
        new() { Font = new("Gabriola"), Size = 10 },
        new() { Font = new("Gadugi"), Size = 10 },
        new() { Font = new("Georgia"), Size = 10 },
        new() { Font = new("Impact"), Size = 10 },
        new() { Font = new("Ink Free"), Size = 10 },
        new() { Font = new("Javanese Text"), Size = 10 },
        new() { Font = new("Leelawadee UI"), Size = 10 },
        new() { Font = new("Lucida Console"), Size = 10 },
        new() { Font = new("Lucida Sans Unicode"), Size = 10 },
        new() { Font = new("Malgun Gothic"), Size = 10 },
        new() { Font = new("MarlettMarlett"), Size = 10 },
        new() { Font = new("Microsoft Himalaya"), Size = 10 },
        new() { Font = new("Microsoft JhengHei"), Size = 10 },
        new() { Font = new("Microsoft New Tai Lue"), Size = 10 },
        new() { Font = new("Microsoft PhagsPa"), Size = 10 },
        new() { Font = new("Microsoft Sans Serif"), Size = 10 },
        new() { Font = new("Microsoft Tai Le"), Size = 10 },
        new() { Font = new("Microsoft YaHei"), Size = 10 },
        new() { Font = new("Microsoft Yi Baiti"), Size = 10 },
        new() { Font = new("MingLiU-ExtB"), Size = 10 },
        new() { Font = new("Mongolian Baiti"), Size = 10 },
        new() { Font = new("MS Gothic"), Size = 10 },
        new() { Font = new("MV Boli"), Size = 10 },
        new() { Font = new("Myanmar Text"), Size = 10 },
        new() { Font = new("Nirmala UI"), Size = 10 },
        new() { Font = new("Palatino Linotype"), Size = 10 },
        new() { Font = new("Segoe Print"), Size = 10 },
        new() { Font = new("Segoe Script"), Size = 10 },
        new() { Font = new("Segoe UI"), Size = 10 },
        new() { Font = new("SimSun"), Size = 10 },
        new() { Font = new("Sitka"), Size = 10 },
        new() { Font = new("Sylfaen"), Size = 10 },
        new() { Font = new("Symbol"), Size = 10 },
        new() { Font = new("Tahoma"), Size = 10 },
        new() { Font = new("Times New Roman"), Size = 10 },
        new() { Font = new("Trebuchet MS"), Size = 10 },
        new() { Font = new("Verdana"), Size = 10 },
        new() { Font = new("Yu Gothic"), Size = 10 },
    ];
}