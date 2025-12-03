using System.Windows;
using getting_real_4.Models.Repositories;

namespace getting_real_4;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private SensorRepository? _repository;

    // Keep App simple; navigation is handled in MainWindow.
    protected override void OnStartup(StartupEventArgs e)
    {
        _repository = new SensorRepository();
        _repository.Load();

        MainWindow = new MainWindow(_repository);
        MainWindow.Show();
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_repository != null)
        {
            MessageBox.Show($"Saving {_repository.GetAllSensors().Count()} sensors...", "Debug");
            _repository.Save();
        }

        base.OnExit(e);
    }
}