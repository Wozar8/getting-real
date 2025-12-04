using System.Collections.ObjectModel;
using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class SensorListingViewModel : ViewModelBase
{
    // The list of sensors shown in the DataGrid.
    private readonly ObservableCollection<SensorViewModel> _sensors;
    public ObservableCollection<SensorViewModel> Sensors => _sensors;

    // We use the repository to load sensors.
    private readonly SensorRepository _repository;

    // The button in the list view binds to this and triggers navigation.
    public ICommand AddSensorCommand { get; }

    // Simplified navigation: callback to show register screen.
    private readonly Action _navigateToRegister;

    public SensorListingViewModel(SensorRepository repository, Action navigateToRegister)
    {
        _sensors = new ObservableCollection<SensorViewModel>();
        _repository = repository;
        _navigateToRegister = navigateToRegister;

        // When the add button is clicked, navigate directly.
        AddSensorCommand = new NavigateCommand(OnAddSensor);

        // Load sensors to display.
        Refresh();
    }

    private void OnAddSensor()
    {
        _navigateToRegister?.Invoke();
    }

    public void Refresh()
    {
        _sensors.Clear();

        foreach (var sensor in _repository.GetAllSensors())
        {
            SensorViewModel sensorViewModel = new SensorViewModel(sensor);
            _sensors.Add(sensorViewModel);
        }
    }
}