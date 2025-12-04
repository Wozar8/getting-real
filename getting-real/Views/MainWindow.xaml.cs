using System.Windows;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;
using getting_real_4.Views;

namespace getting_real_4;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // We keep one shared repository so both screens see the same sensors.
    private readonly SensorRepository _repository;

    // Keep reference to the listing VM so we can refresh after registering.
    private SensorListingViewModel? _listingVm;

    // Keep a single listing window instance.
    private SensorListingView? _listingWindow;

    public MainWindow(SensorRepository repository)
    {
        _repository = repository;
        InitializeComponent();
        // Start by showing the sensor list screen as a window.
        ShowSensorListing();
    }

    // Expose repository so App can save on exit
    public SensorRepository Repository => _repository;

    // This method shows the list of sensors.
    private void ShowSensorListing()
    {
        if (_listingWindow == null)
        {
            _listingVm = new SensorListingViewModel(_repository, ShowRegisterSensor);
            _listingWindow = new SensorListingView { DataContext = _listingVm };
            _listingWindow.Show();
        }
        else
        {
            _listingVm?.Refresh();
            _listingWindow.Activate();
        }
    }

    // This method shows the register/new sensor screen as a modal dialog.
    private void ShowRegisterSensor()
    {
        var registerWindow = new RegisterSensorView();
        var registerVm = new RegisterSensorViewModel(_repository, () =>
        {
            // After adding, refresh the listing and close the dialog.
            _listingVm?.Refresh();
            registerWindow.Close();
        });
        registerWindow.DataContext = registerVm;
        registerWindow.ShowDialog();
    }
}