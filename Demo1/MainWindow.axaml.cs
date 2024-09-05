using Avalonia.Controls;
using System.Linq;

namespace Demo1
{
    public partial class MainWindow : Window
    {
        string search = ""; 
        int sort = 0;
        int filtr = 0;
        public MainWindow()
        {
            InitializeComponent();
            Sort.SelectedIndex = 0;
            ShownAmount.Text = ServicesActions.ShowmAmount;
            Filtr.SelectedIndex = 0;
            ServiceList.ItemsSource = ServicesActions.ListServices;
            Add.IsVisible = ServicesActions.IsAdmin;
        }
        private void AddButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new RedactWindow().Show();
            this.Close();
        }

        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
        {
            search = Search.Text;
            ServicesActions.SomethingChanged(search, sort, filtr);
            ServiceList.ItemsSource = ServicesActions.ListServices;
            ShownAmount.Text = ServicesActions.ShowmAmount;
        }

        private void SortChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            sort = Sort.SelectedIndex;
            ServicesActions.SomethingChanged(search, sort, filtr);
            ServiceList.ItemsSource = ServicesActions.ListServices;
            ShownAmount.Text = ServicesActions.ShowmAmount;
        }

        private void FiltrChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            filtr = Filtr.SelectedIndex;
            ServicesActions.SomethingChanged(search, sort, filtr);
            ServiceList.ItemsSource = ServicesActions.ListServices;
            ShownAmount.Text = ServicesActions.ShowmAmount;
        }
    }
}