using System.IO;
using System.Reflection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BussyControl;
public sealed partial class Bussy : UserControl
{
    public Bussy()
    {
        this.InitializeComponent();
        LoadEmbeddedImage();
    }

    private void LoadEmbeddedImage()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "BussyControl.Assets.yuzu.png";

        using Stream stream = assembly.GetManifestResourceStream(resourceName);
        if (stream != null)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(stream.AsRandomAccessStream());
            MyImageControl.Source = bitmapImage;
        }
    }
    public bool IsBussy
    {
        get => (bool)GetValue(IsBussyProperty);
        set => SetValue(IsBussyProperty, value);
    }

    // Using a DependencyProperty as the backing store for IsBussy.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsBussyProperty =
        DependencyProperty.Register("IsBussy", typeof(bool), typeof(Bussy), new PropertyMetadata(false, OnIsBussyChanged));

    private static void OnIsBussyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Bussy bussy)
        {
            bussy.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
        }
    }

}
