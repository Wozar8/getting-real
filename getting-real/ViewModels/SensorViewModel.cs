using getting_real_4.Models;

namespace getting_real_4.ViewModels;

public class SensorViewModel
{
    private readonly Sensor _senor;

    public string Id { get; set; } // TODO: Add OnPropertyChange for all properties
    public string Type { get; set; }
    public string Keys { get; set; }
    public string SensorType { get; set; }
    public string ConnectionType { get; set; }

    public ICommand AddSensorCommand { get; }

    public SensorViewModel(Sensor sensor)
    {
        _senor = sensor;
        this.Id = _senor.Id.ToString();
        this.Type = _senor.Type;
        this.Keys = _senor.Keys;
        this.SensorType = _senor.SensorType;
        this.ConnectionType = _senor.ConnectionType;
    }
}