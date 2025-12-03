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

    // Event that tells the window to show the register screen.
    public event EventHandler? AddSensorRequested;

    public SensorListingViewModel(SensorRepository repository)
    {
        _sensors = new ObservableCollection<SensorViewModel>();
        _repository = repository;

        // When the add button is clicked, raise an event.
        AddSensorCommand = new NavigateCommand(OnAddSensor);

        // Load sensors to display.
        UpdateRegisteredSensors();
    }

    private void OnAddSensor()
    {
        // Use concise null-conditional invocation instead of the older local-delegate pattern.
        AddSensorRequested?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateRegisteredSensors()
    {
        _sensors.Clear();

        foreach (var sensor in _repository.GetAllSensors())
        {
            SensorViewModel sensorViewModel = new SensorViewModel(sensor);
            _sensors.Add(sensorViewModel);
        }
    }
}