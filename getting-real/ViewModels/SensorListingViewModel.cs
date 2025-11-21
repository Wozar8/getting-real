using System.Collections.ObjectModel;
using System.Windows.Input;
using getting_real_4.Models;

namespace getting_real_4.ViewModels;

public class SensorListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<SensorViewModel> _sensors;
    public ObservableCollection<SensorViewModel> Sensors => _sensors;

    public ICommand AddSensorCommand { get; }

    public SensorListingViewModel()
    {
        _sensors = new ObservableCollection<SensorViewModel>();
        _sensors.Add(new SensorViewModel(new Sensor("1", "Temperature", "Key1", "Thermometer")));
        _sensors.Add(new SensorViewModel(new Sensor("2", "Humidity", "Key2", "Hygrometer")));
        _sensors.Add(new SensorViewModel(new Sensor("3", "Pressure", "Key3", "Barometer")));
        _sensors.Add(new SensorViewModel(new Sensor("4", "Light", "Key4", "Photometer")));
        _sensors.Add(new SensorViewModel(new Sensor("5", "Motion", "Key5", "PIR Sensor")));
    }
}