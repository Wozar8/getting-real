using System.Collections.ObjectModel;
using System.Windows.Input;
using getting_real_4.Models;

namespace getting_real_4.ViewModels;

public class SensorListingViewModel : ViewModelBase
{
    public SensorListingViewModel()
    {
        Sensors = new ObservableCollection<SensorViewModel>();
        Sensors.Add(new SensorViewModel(new Sensor("1", "Temperature", "Key1", "Thermometer")));
        Sensors.Add(new SensorViewModel(new Sensor("2", "Humidity", "Key2", "Hygrometer")));
        Sensors.Add(new SensorViewModel(new Sensor("3", "Pressure", "Key3", "Barometer")));
        Sensors.Add(new SensorViewModel(new Sensor("4", "Light", "Key4", "Photometer")));
        Sensors.Add(new SensorViewModel(new Sensor("5", "Motion", "Key5", "PIR Sensor")));
    }

    public ObservableCollection<SensorViewModel> Sensors { get; }

    public ICommand AddSensorCommand { get; }
}