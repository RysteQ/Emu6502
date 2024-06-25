using Emu6502.Models.CodeEditorModels;
using Emu6502.Services.BaseModels;
using Emu6502.Views;
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
        CommandShowAboutPage = new(ShowAboutPage);
        CommandExecuteEmulator = new(ExecuteEmulator);
        CommandEmulatorSettings = new(EmulatorSettings);
        CommandIncreaseFontSize = new(IncreaseFontSize);
        CommandDecreaseFontSize = new(DecreaseFontSize);
        CommandChangeFont = new(ChangeFont);
    }

    private void OpenFile()
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "Assembly Source File (*.asm)|*.asm|Text (*.txt)|*.txt|All Files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == false)
        {
            return;
        }

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
        if (OpenedFile.FilePath == string.Empty)
        {
            SaveFileAs();

            return;
        }

        File.WriteAllText(OpenedFile.FilePath, OpenedFile.Contents);
    }

    private void SaveFileAs()
    {
        SaveFileDialog saveFileDialog = new()
        {
            Filter = "Assembly Source File (*.asm)|*.asm|Text (*.txt)|*.txt|All Files (*.*)|*.*"
        };

        if (saveFileDialog.ShowDialog() == false)
        {
            return;
        }

        OpenedFile.Filename = saveFileDialog.FileName.Split('\\').Last();
        OpenedFile.FilePath = string.Join('\\', saveFileDialog.FileName.Split('\\').SkipLast(1));

        File.WriteAllText(saveFileDialog.FileName, OpenedFile.Contents);
    }

    private void CloseApplication()
    {
        Environment.Exit(0);
    }

    private void ShowAboutPage()
    {
        AboutView about = new();

        about.Show();
    }

    private void ExecuteEmulator()
    {
        // TODO
    }

    private void EmulatorSettings()
    {
        // TODO
    }

    private void IncreaseFontSize()
    {
        EditorFont.Size++;
    }

    private void DecreaseFontSize()
    {
        EditorFont.Size--;
    }

    private void ChangeFont()
    {
        FontDialogView fontDialog = new();

        fontDialog.Show();
    }

    public Command CommandOpenFile { get; init; }
    public Command CommandSaveFile { get; init; }
    public Command CommandSaveFileAs { get; init; }
    public Command CommandCloseApplication { get; init; }
    public Command CommandShowAboutPage { get; init; }
    public Command CommandExecuteEmulator { get; init; }
    public Command CommandEmulatorSettings { get; init; }
    public Command CommandIncreaseFontSize { get; init; }
    public Command CommandDecreaseFontSize { get; init; }
    public Command CommandChangeFont { get; init; }

    private FileUi _openedFile = new();
    public FileUi OpenedFile
    {
        get => _openedFile;
        set => SetProperty(ref _openedFile, value);
    }

    private FontUi _editorFont = new();
    public FontUi EditorFont
    {
        get => _editorFont;
        set => SetProperty(ref _editorFont, value);
    }
}