using System.Windows;
using getting_real_4.Models.Repositories;
using getting_real_4.Views;
using getting_real_4.ViewModels;

namespace getting_real_4;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private SensorRepository? _repository;

    protected override void OnStartup(StartupEventArgs e)
    {
        _repository = new SensorRepository();
        _repository.Load();

        // Use MainWindow as the shell and delegate navigation to it.
        var mainWindow = new MainWindow(_repository);
        MainWindow = mainWindow;
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_repository != null)
        {
            _repository.Save();
        }

        base.OnExit(e);
    }
}