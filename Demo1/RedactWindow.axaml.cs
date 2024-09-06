using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media;
using Demo1.Models;

namespace Demo1;

public partial class RedactWindow : Window
{
    public bool redact = false;
    public RedactWindow()
    {
        InitializeComponent();
        RWindow.Title = "Добавление услуги";
    }
    public RedactWindow(int Ind)
    {
        InitializeComponent();
        RWindow.Title = "Редактирование услуги";
        Service service = new Service();
        service = ServicesActions.DBContext.Services.ToList().FirstOrDefault(s => s.Id == Ind);
        Name.Text = service.Title;
        Cost.Text = service.Cost.ToString();
        Time.Text = service.Durationinminutes.ToString();
        Desc.Text = service.Description;
        Discount.Text = (service.Discount*100).ToString();
        redact = true;

    }
    public async void AddImage()
    {
        string FileToCopy;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var TopLevel = await openFileDialog.ShowAsync(this);
        FileToCopy = string.Join("", TopLevel);
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (redact)
        {

        }
        else
        {
            Service service = new Service() { Title = Name.Text, Cost = float.Parse(Cost.Text), Description = Desc.Text, Discount = (Int32.Parse(Discount.Text))/100};
        }
    }

    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        if (!float.TryParse((sender as TextBox).Text, out float result) && (sender as TextBox).Text.Length!=0)
        {
            (sender as TextBox).BorderBrush = Brushes.Red;
            (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length-1);
        }
    }

    private void TextBox_TextChanged_1(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        if (!float.TryParse((sender as TextBox).Text, out float result) && result > 100 && result < 0)
        {
            (sender as TextBox).BorderBrush = Brushes.Red;
            (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
        }
    }
}