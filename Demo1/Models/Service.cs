using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Demo1.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public float Cost { get ; set; }

    public int Durationinminutes { get; set; }

    public string? Description { get; set; }

    public double? Discount { get; set; }

    public string? Mainimagepath { get; set; }

    public Bitmap ImageBitmap
    {
        get => new Bitmap(AssetLoader.Open(new Uri($"avares://Demo1/Assets/{Mainimagepath}")));
    }

    public bool HasDiscount { get => Discount != 0; }
    public float CostWithDiscount
    {
        get => (float)(Cost * (1 - Discount));
    }
    public string BackgroundColor
    {
        get { if (HasDiscount) return "LightGreen"; else return "White";}
    }
    public string StringDiscount
    {
        get { return $"* скидка {Discount * 100}%"; }
    }
    public virtual ICollection<Clientservice> Clientservices { get; set; } = new List<Clientservice>();

    public virtual ICollection<Servicephoto> Servicephotos { get; set; } = new List<Servicephoto>();
}
