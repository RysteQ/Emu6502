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

    private void ListBoxSelectedFontSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LabelFontSampleText.FontFamily = _viewModel.SelectedFont.Font;
    }

    private void ButtonIncreaseFontSizeClick(object sender, RoutedEventArgs e)
    {
        LabelFontSampleText.FontSize++;
    }

    private void ButtonDecreaseFontSizeClick(object sender, RoutedEventArgs e)
    {
        LabelFontSampleText.FontSize--;
    }

    private FontDialogVM _viewModel;
}