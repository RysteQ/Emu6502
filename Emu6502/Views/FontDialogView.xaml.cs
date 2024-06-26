﻿using Emu6502.Models.CodeEditor;
using Emu6502.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Emu6502.Views;

/// <summary>
/// Interaction logic for FontDialogView.xaml
/// </summary>
public partial class FontDialogView : Window
{
    public FontDialogView()
    {
        InitializeComponent();

        _viewModel = new();
        DataContext = _viewModel;
    }

    public FontDialogView(string fontFamily, double fontSize)
    {
        InitializeComponent();

        _viewModel = new(fontFamily, fontSize);
        DataContext = _viewModel;

        LabelFontSampleText.FontFamily = _viewModel.SelectedFont.Font;
        LabelFontSampleText.FontSize = _viewModel.SelectedFont.Size;
    }

    private void ButtonSaveFormClick(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
        Close();
    }

    private void ButtonCancelFormClick(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
        Close();
    }

    private void ButtonFontSizeChangedClick(object sender, RoutedEventArgs e)
    {
        LabelFontSampleText.FontSize = _viewModel.SelectedFont.Size;
    }

    private void ListBoxSelectedItemSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LabelFontSampleText.FontFamily = _viewModel.SelectedFont.Font;
    }

    public FontUi Font
    {
        get => _viewModel.SelectedFont;
    }

    private FontDialogVM _viewModel;
}