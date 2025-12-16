using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models;

namespace getting_real_4.ViewModels;

// This is a helper file for the SensorListingViewModel.cs
public class SensorViewModel : ViewModelBase
{
    private readonly Sensor _sensor;

    public SensorViewModel(Sensor sensor)
    {
        _sensor = sensor;
        ReplaceBatteryCommand = new ReplaceBatteryCommand(this);
    }

    public string Id => _sensor.Id.ToString();

    public string Type
    {
        get => _sensor.Type;
        set
        {
            _sensor.Type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    public string Keys
    {
        get => _sensor.Keys;
        set
        {
            _sensor.Keys = value;
            OnPropertyChanged(nameof(Keys));
        }
    }

    public string SensorType
    {
        get => _sensor.SensorType;
        set
        {
            _sensor.SensorType = value;
            OnPropertyChanged(nameof(SensorType));
        }
    }

    public string ConnectionType
    {
        get => _sensor.ConnectionType;
        set
        {
            _sensor.ConnectionType = value;
            OnPropertyChanged(nameof(ConnectionType));
        }
    }

    public bool InStorage
    {
        get => _sensor.InStorage;
        set
        {
            _sensor.InStorage = value;
            OnPropertyChanged(nameof(InStorage));
        }
    }

    public int BatteryReplacementCount
    {
        get => _sensor.BatteryReplacementCount;
        set
        {
            _sensor.BatteryReplacementCount = value;
            OnPropertyChanged(nameof(BatteryReplacementCount));
        }
    }

    // This command is put here as this class purview' is each entry in the DataList
    public ICommand ReplaceBatteryCommand { get; }

    public void ReplaceBattery()
    {
        _sensor.ReplaceBattery();
        OnPropertyChanged(nameof(BatteryReplacementCount));
    }
}
