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
    private readonly SensorRepository _repository = new SensorRepository();

    public MainWindow()
    {
        InitializeComponent();
        ShowSensorListing();
    }

    private void ShowSensorListing()
    {
        var vm = new SensorListingViewModel(_repository);
        var view = new SensorListingView { DataContext = vm };
        MainContent.Content = view;

        // Handle navigation to register view when AddSensorCommand is executed
        vm.AddSensorRequested += (_, __) => ShowRegisterSensor();
    }

    private void ShowRegisterSensor()
    {
        var vm = new RegisterSensorViewModel(_repository);
        var view = new RegisterSensorView { DataContext = vm };
        MainContent.Content = view;

        // Navigate back on cancel or after add
        vm.CancelRequested += (_, __) => ShowSensorListing();
        vm.AddCompleted += (_, __) => ShowSensorListing();
    }
}