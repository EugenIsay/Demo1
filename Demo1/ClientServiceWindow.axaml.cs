using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1;

public partial class ClientServiceWindow : Window
{
    string Name = "-----";
    string Hours = "--:--";
    string Hours2 = "--:--";
    string Date = "--,--,--";
    public List<string> Names = new List<string>();
    public Service service = new Service();
    public ClientServiceWindow()
    {
        InitializeComponent();
        Info.Text = $"{Name} назначен(-на) на {Date} в {Hours}";
    }
    public ClientServiceWindow(string ind)
    {
        InitializeComponent();
        //CS = ServicesActions.DBContext.Clientservices.ToList<Clientservice>().Where(s => s.Serviceid == Int32.Parse(ind)).ToList();
        //foreach (Clientservice report in CS)
        //{
        //    Names.Add(ServicesActions.DBContext.Clients.FirstOrDefault(c => c.Id == report.Clientid).FullName);
        //}
        Info.Text = $"{Name} назначен(-на) на {Date} в {Hours}, услуга продлится до {Hours2}";
        Names = ServicesActions.DBContext.Clients.ToList().Select(c => c.FullName).Order().ToList();
        People.ItemsSource = Names;
        service = ServicesActions.DBContext.Services.ToList().FirstOrDefault(s => s.Id == Int32.Parse(ind));
        Title.Text = service.Title;
        Time.Text = service.Durationinminutes.ToString();
        Image.Source = new Bitmap(Environment.CurrentDirectory + "\\Assets\\" + service.Mainimagepath);
    }

    private void TimePicker_SelectedTimeChanged(object? sender, Avalonia.Controls.TimePickerSelectedValueChangedEventArgs e)
    {
        Hours = (sender as TimePicker).SelectedTime.ToString();

        Hours2 = (sender as TimePicker).SelectedTime.Value.Add(TimeSpan.FromMinutes(service.Durationinminutes)).ToString();
        Info.Text = $"{Name} назначен(-на) на {Date} в {Hours}, услуга продлится до {Hours2}";
    }

    private void Calendar_SelectedDatesChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        Date = (sender as Calendar).SelectedDate.ToString();
        Info.Text = $"{Name} назначен(-на) на {Date} в {Hours}, услуга продлится до {Hours2}";
    }

    private void ComboBox_SelectionChanged_1(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        Name = Names[(sender as ComboBox).SelectedIndex];
        Info.Text = $"{Name} назначен(-на) на {Date} в {Hours}, услуга продлится до {Hours2}";
    }
}