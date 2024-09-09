using Avalonia.Controls;
using Demo1.Models;
using System;
using System.IO;
using System.Linq;

namespace Demo1
{
    public partial class MainWindow : Window
    {
        string search = "";
        int sort = 0;
        int filtr = 0;
        public void Restart()
        {
            Search.Text = "";
            Sort.SelectedIndex = 0;
            Filtr.SelectedIndex = 0;
            ServiceList.ItemsSource = ServicesActions.ListServices;
            ShownAmount.Text = ServicesActions.ShowmAmount;
        }

        public MainWindow()
        {
            InitializeComponent();
            Restart();
        }
        private void AddButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new RedactWindow().Show();
            Close();
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

        private void Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string serviceID = (sender as Button).Tag.ToString();
            new RedactWindow(Convert.ToInt32(serviceID)).Show();
            Close();
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Restart();
            new FirstWindow().Show();
            this.Close();
        }

        private void Grid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            new ClientServiceWindow((sender as Border).Tag.ToString()).Show();
            Close();
        }

        private void Delete(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string serviceID = (sender as Button).Tag.ToString();
            Service service = ServicesActions.DBContext.Services.FirstOrDefault(s => s.Id == Int32.Parse(serviceID));
            FileInfo file = new FileInfo($"{Environment.CurrentDirectory}\\Assets\\{service.Mainimagepath}");
            file.Delete();
            ServicesActions.DBContext.Services.Remove(service);
            ServicesActions.DBContext.SaveChanges();
            Restart();
        }
    }
}