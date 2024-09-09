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
using Microsoft.EntityFrameworkCore.Infrastructure;
using Avalonia.Platform;

namespace Demo1;

public partial class RedactWindow : Window
{
    public bool redact = false;
    public int Index = -1;
    string FilePath = "";
    string FileName = "";
    string FileToCopy = "";
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
        FileName = service.Mainimagepath;
        FilePath = Environment.CurrentDirectory + "\\Assets\\" + FileName;
        Image.Source = new Bitmap(FilePath);
        redact = true;
        Index = Ind;
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!String.IsNullOrEmpty(Name.Text) && !String.IsNullOrEmpty(Cost.Text) && !String.IsNullOrEmpty(Time.Text) && !String.IsNullOrEmpty(FileName))
        {
            if (Discount.Text == null)
            {
                Discount.Text = "0";
            }
            if (redact)
            {
                Service service = ServicesActions.DBContext.Services.FirstOrDefault(s => s.Id == Index);
                service.Title = Name.Text;
                service.Cost = float.Parse(Cost.Text);
                service.Durationinminutes = Int32.Parse(Time.Text);
                service.Description = Desc.Text;
                service.Discount = Int32.Parse(Discount.Text) / 100;
                service.Mainimagepath = FileName;
                ServicesActions.DBContext.Services.Update(service);
                ServicesActions.DBContext.SaveChanges();
                if (FileToCopy != "")
                {
                    File.Copy(FileToCopy, $"{Environment.CurrentDirectory}/Assets/{FileName}");
                    FileInfo file = new FileInfo(FilePath);
                    file.Delete();
                }
            }
            else
            {
                if (ServicesActions.DBContext.Services.ToList().Where(t => t.Title == Name.Text).Count() != 0)
                {
                    return;
                }
                Service service = new Service() { Title = Name.Text, Cost = float.Parse(Cost.Text), Durationinminutes = Int32.Parse(Time.Text), Description = Desc.Text, Discount = (Int32.Parse(Discount.Text)) / 100, Mainimagepath = FileName};
                ServicesActions.DBContext.Services.Add(service);
                File.Copy(FileToCopy, $"{Environment.CurrentDirectory}/Assets/{FileName}");
                ServicesActions.DBContext.SaveChanges();
            }
            new MainWindow().Show();
            ServicesActions.Fill();
            this.Close();
        }
    }

    private async void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        if (!float.TryParse((sender as TextBox).Text, out float result) && (sender as TextBox).Text.Length!=0)
        {
            (sender as TextBox).Foreground = Brushes.Red;
            (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length-1);
            await Task.Delay(500);
            (sender as TextBox).Foreground = Brushes.Black;
        }
    }

    private async void TextBox_TextChanged_1(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        if ((!float.TryParse((sender as TextBox).Text, out float result) || (result > 99 || result < 0)) && (sender as TextBox).Text.Length != 0)
        {
            (sender as TextBox).Foreground = Brushes.Red;
            (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            await Task.Delay(500);
            (sender as TextBox).Foreground = Brushes.Black;
        }
    }

    private async void AddImage(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var TopLevel = await openFileDialog.ShowAsync(this);
        FileToCopy = string.Join("", TopLevel);
        if (FileToCopy != "")
        {
            var folderPath = $"{Environment.CurrentDirectory}\\Assets";
            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
            int pos = FileToCopy.LastIndexOf('.');
            string str = FileToCopy.Substring(pos, FileToCopy.Length - pos);
            if (folderInfo.GetFiles().Where(f => f.FullName == str).Count() == 0)
            {
                Image.Source = new Bitmap(FileToCopy);
                FileName = System.Guid.NewGuid().ToString() + str;
            }
        }
    }

    private async void TextBox_TextChanged_2(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        if ((!float.TryParse((sender as TextBox).Text, out float result) || (result > 240 || result < 1)) && (sender as TextBox).Text.Length != 0)
        {
            (sender as TextBox).Foreground = Brushes.Red;
            (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            await Task.Delay(500);
            (sender as TextBox).Foreground = Brushes.Black;
        }
    }
}