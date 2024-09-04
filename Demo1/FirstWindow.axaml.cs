using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Demo1;

public partial class FirstWindow : Window
{
    public FirstWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new MainWindow(false).Show();
        this.Close();
    }
    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        if (ForAdmin.Text == "0000")
        {
            new MainWindow(true).Show();
            this.Close();
        }
    }
}