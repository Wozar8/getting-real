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

    // Keep App simple; navigation is handled by opening windows directly.
    protected override void OnStartup(StartupEventArgs e)
    {
        _repository = new SensorRepository();
        _repository.Load();

        // Create the listing window and wire navigation to open the register window as a dialog.
        SensorListingView? listingWindow = null;
        SensorListingViewModel? listingVm = null;

        var navigateToRegister = new Action(() =>
        {
            var registerWindow = new RegisterSensorView();
            var registerVm = new RegisterSensorViewModel(_repository, () =>
            {
                // After adding, refresh the listing and close the dialog.
                listingVm?.Refresh();
                registerWindow.Close();
            });
            registerWindow.DataContext = registerVm;
            registerWindow.ShowDialog();
        });

        listingVm = new SensorListingViewModel(_repository, navigateToRegister);
        listingWindow = new SensorListingView { DataContext = listingVm };

        MainWindow = listingWindow;
        listingWindow.Show();
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