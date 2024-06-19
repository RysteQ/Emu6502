using Emu6502.Models.CodeEditorModels;
using Emu6502.Services.BaseModels;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Emu6502.ViewModels;

public class CodeEditorVM : BaseViewModel
{
    public CodeEditorVM()
    {
        CommandOpenFile = new(OpenFile);
        CommandSaveFile = new(SaveFile);
        CommandSaveFileAs = new(SaveFileAs);
        CommandCloseApplication = new(CloseApplication);
    }

    private void OpenFile()
    {
        OpenFileDialog openFileDialog = new();

        openFileDialog.Filter = "Assembly Source File (*.asm)|*.asm|Text (*.txt)|*.txt|All Files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == false)
            return;

        if (OpenedFile.ValueChanged)
        {
            MessageBoxResult unsavedChangesQuestionResult = MessageBox.Show("You have unsaved changes, do you wish to save them now ?", "Warning", MessageBoxButton.YesNoCancel);

            if (unsavedChangesQuestionResult == MessageBoxResult.Yes)
            {
                SaveFile();
            }
            else if (unsavedChangesQuestionResult == MessageBoxResult.Cancel)
            {
                return;
            }
        }

        OpenedFile = new()
        {
            Filename = openFileDialog.FileName,
            FilePath = openFileDialog.FileName.Split('\\').Last(),
            Contents = File.ReadAllText(openFileDialog.FileName)
        };
    }

    private void SaveFile()
    {

    }

    private void SaveFileAs()
    {

    }

    private void CloseApplication()
    {
        Environment.Exit(0);
    }

    public Command CommandOpenFile { get; init; }
    public Command CommandSaveFile { get; init; }
    public Command CommandSaveFileAs { get; init; }
    public Command CommandCloseApplication { get; init; }

    private FileUi _openedFile = new();
    public FileUi OpenedFile
    {
        get => _openedFile;
        set => SetProperty(ref _openedFile, value);
    }
}