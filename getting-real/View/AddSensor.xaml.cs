using System.Windows;

namespace getting_real.View;

/// <summary>
///     Interaction logic for AddSensor.xaml
/// </summary>
public partial class AddSensor : Window
{
    public AddSensor()
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