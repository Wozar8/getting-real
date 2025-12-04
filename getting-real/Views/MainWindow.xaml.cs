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

    // Track currently shown child window and close it when switching.
    private Window? _currentChildWindow;

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
        CloseCurrentChildWindowIfAny();
        var vm = new SensorListingViewModel(_repository, ShowRegisterSensor);
        var window = new SensorListingView { DataContext = vm };
        _currentChildWindow = window;
        window.Show();
    }

    // This method shows the register/new sensor screen.
    private void ShowRegisterSensor()
    {
        CloseCurrentChildWindowIfAny();
        var vm = new RegisterSensorViewModel(_repository, ShowSensorListing);
        var window = new RegisterSensorView { DataContext = vm };
        _currentChildWindow = window;
        window.Show();
    }

    private void CloseCurrentChildWindowIfAny()
    {
        if (_currentChildWindow != null)
        {
            // Unset DataContext to help GC and then close.
            _currentChildWindow.DataContext = null;
            _currentChildWindow.Close();
            _currentChildWindow = null;
        }
    }
}