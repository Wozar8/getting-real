using getting_real_4.Models;

namespace getting_real_4.ViewModels;

public class SensorViewModel : ViewModelBase
{
    private readonly Sensor _senor;

    public SensorViewModel(Sensor sensor)
    {
        _senor = sensor;
        Id = _senor.Id.ToString();
        Type = _senor.Type;
        Keys = _senor.Keys;
        SensorType = _senor.SensorType;
        ConnectionType = _senor.ConnectionType;
    }

    public string Id { get; set; }
    public string Type { get; set; }
    public string Keys { get; set; }
    public string SensorType { get; set; }
    public string ConnectionType { get; set; }
}