using Emu6502.Services.BaseModels;

namespace Emu6502.Models.CodeEditorModels;

public class FileUi : BaseUiModel
{
    private string _fileName = string.Empty;
    public string Filename
    {
        get => _fileName;
        set => SetProperty(ref _fileName, value);
    }

    private string _filePath = string.Empty;
    public string FilePath
    {
        get => _filePath;
        set => SetProperty(ref _filePath, value);
    }

    private string _contents = string.Empty;
    public string Contents
    {
        get => _contents;
        set => SetProperty(ref _contents, value);
    }
}