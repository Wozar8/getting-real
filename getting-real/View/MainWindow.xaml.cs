using System.Windows;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
namespace getting_real.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var sensorView = new SensorView();
        sensorView.Show();
        Close();
    }
}