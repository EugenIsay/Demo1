using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Demo1.Models;

public partial class Servicephoto
{
    public int Id { get; set; }

    public int Serviceid { get; set; }

    public string Photopath { get; set; } = null!;

    public Bitmap ImageBitmap
    {
        get
        {
            var a = new Uri($"avares://Demo1/Assets/{Photopath}");
            return new Bitmap(Environment.CurrentDirectory + "/Assets/" + Photopath);
        }
    }

    public virtual Service Service { get; set; } = null!;
}
