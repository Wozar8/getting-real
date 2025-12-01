using getting_real_4.Models;

namespace getting_real_4.ViewModels;

// This is a helper file for the SensorListingViewModel.cs
public class SensorViewModel : ViewModelBase
{
    private readonly Sensor _senor;

    public SensorViewModel(Sensor sensor)
    {
        _senor = sensor;
    }

    public string Id => _senor.Id.ToString();

    public string Type
    {
        get => _senor.Type;
        set
        {
            _senor.Type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    public string Keys
    {
        get => _senor.Keys;
        set
        {
            _senor.Keys = value;
            OnPropertyChanged(nameof(Keys));
        }
    }

    public string SensorType
    {
        get => _senor.SensorType;
        set
        {
            _senor.SensorType = value;
            OnPropertyChanged(nameof(SensorType));
        }
    }

    public string ConnectionType
    {
        get => _senor.ConnectionType;
        set
        {
            _senor.ConnectionType = value;
            OnPropertyChanged(nameof(ConnectionType));
        }
    }
}