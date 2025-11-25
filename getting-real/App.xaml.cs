using System.Configuration;
using System.Data;
using System.Windows;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;

namespace getting_real_4;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly SensorRepository _repository;

    public App()
    {
        _repository = new SensorRepository();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_repository)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }
}