using System.Windows;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;

namespace getting_real_4;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    // Keep App simple; navigation is handled in MainWindow.
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow();
        MainWindow.Show();
        base.OnStartup(e);
    }
}