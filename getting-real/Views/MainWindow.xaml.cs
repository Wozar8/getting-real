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
    private readonly SensorRepository _repository = new SensorRepository();

    public MainWindow()
    {
        InitializeComponent();
        // Start by showing the sensor list screen.
        ShowSensorListing();
    }

    // This method shows the list of sensors.
    private void ShowSensorListing()
    {
        // Create the ViewModel that holds data and actions for the list screen.
        var vm = new SensorListingViewModel(_repository);
        // Create the visual control and connect it to the ViewModel.
        var view = new SensorListingView { DataContext = vm };
        // Put the view into the ContentControl defined in MainWindow.xaml.
        MainContent.Content = view;

        // When the user clicks "Add sensor", switch to the register screen.
        vm.AddSensorRequested += OnAddSensorRequested;
    }

    private void OnAddSensorRequested(object? sender, System.EventArgs e)
    {
        ShowRegisterSensor();
    }

    // This method shows the register/new sensor screen.
    private void ShowRegisterSensor()
    {
        var vm = new RegisterSensorViewModel(_repository);
        var view = new RegisterSensorView { DataContext = vm };
        MainContent.Content = view;

        // If the user cancels or after we successfully add, go back to the list.
        vm.CancelRequested += OnCancelRequested;
        vm.AddCompleted += OnAddCompleted;
    }

    private void OnCancelRequested(object? sender, System.EventArgs e)
    {
        ShowSensorListing();
    }

    private void OnAddCompleted(object? sender, System.EventArgs e)
    {
        ShowSensorListing();
    }
}