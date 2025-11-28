using System.Windows;
using getting_real_4.Models.Repositories;
using getting_real_4.Services;
using getting_real_4.Stores;
using getting_real_4.ViewModels;

namespace getting_real_4;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly NavigationStore _navigationStore;
    private readonly SensorRepository _repository;

    public App()
    {
        _repository = new SensorRepository();
        _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _navigationStore.CurrentViewModel = CreateSensorListingViewModel();
        MainWindow = new MainWindow
        {
            DataContext = new MainViewModel(_navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }

    private RegisterSensorViewModel CreateRegisterSensorViewModel()
    {
        return new RegisterSensorViewModel(_repository,
            new NavigationService(_navigationStore, CreateSensorListingViewModel));
    }

    private SensorListingViewModel CreateSensorListingViewModel()
    {
        return new SensorListingViewModel(_repository,
            new NavigationService(_navigationStore, CreateRegisterSensorViewModel));
    }
}