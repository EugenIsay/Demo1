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

namespace Demo1;

public partial class RedactWindow : Window
{
    public RedactWindow()
    {
        InitializeComponent();
    }
    public RedactWindow(int Ind)
    {
        InitializeComponent();
    }
    public async void AddImage()
    {
        string FileToCopy;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var TopLevel = await openFileDialog.ShowAsync(this);
        FileToCopy = string.Join("", TopLevel);
    }
}