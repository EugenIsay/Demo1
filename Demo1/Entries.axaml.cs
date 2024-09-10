using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1;

public partial class Entries : Window
{
    public List<Clientservice> CS= new List<Clientservice>();
    public Entries()
    {
        InitializeComponent();
        CS = ServicesActions.DBContext.Clientservices.ToList().Where(s => s.Starttime <= DateTime.Now.AddDays(2) && s.Starttime >= DateTime.Now).OrderBy(d => d.Starttime).ToList();
        foreach (Clientservice report in CS)
        {
            report.Service = ServicesActions.DBContext.Services.ToList().FirstOrDefault(s => s.Id == report.Serviceid);
            report.Client = ServicesActions.DBContext.Clients.ToList().FirstOrDefault(s => s.Id == report.Clientid);
        }
        ListCS.ItemsSource = CS.ToList();
    }
}