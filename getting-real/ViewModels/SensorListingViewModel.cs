using System.Collections.ObjectModel;
using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models;
using getting_real_4.Models.Repositories;
using getting_real_4.Services;
using getting_real_4.Stores;

namespace getting_real_4.ViewModels;

public class SensorListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<SensorViewModel> _sensors;
    public ObservableCollection<SensorViewModel> Sensors => _sensors;
    private SensorRepository _repository;
    public ICommand AddSensorCommand { get; }

    public SensorListingViewModel(SensorRepository repository, NavigationService registorSensorViewNavigationService)
    {
        _sensors = new ObservableCollection<SensorViewModel>();
        _repository = repository;

        AddSensorCommand = new NavigateCommand(registorSensorViewNavigationService);

        UpdateRegisteredSensors();
        // Sensors.Add(new SensorViewModel(new Sensor("1", "Temperature", "Key1", "Thermometer")));
        // Sensors.Add(new SensorViewModel(new Sensor("2", "Humidity", "Key2", "Hygrometer")));
        // Sensors.Add(new SensorViewModel(new Sensor("3", "Pressure", "Key3", "Barometer")));
        // Sensors.Add(new SensorViewModel(new Sensor("4", "Light", "Key4", "Photometer")));
        // Sensors.Add(new SensorViewModel(new Sensor("5", "Motion", "Key5", "PIR Sensor")));
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