using System.Windows;

namespace getting_real.View;

/// <summary>
///     Interaction logic for SensorView.xaml
/// </summary>
public partial class SensorView : Window
{
    public SensorView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}