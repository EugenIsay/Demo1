using Avalonia.Controls;
using Demo1.Controllers;

namespace Demo1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(bool IsAdmin)
        {
            InitializeComponent();
            ServiceController.GetService();
            Add.IsVisible = IsAdmin;
        }
        private void AddButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new RedactWindow().Show();
            this.Close();
        }
    }
}