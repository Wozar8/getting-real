using getting_real_4.Models;

namespace getting_real_4.ViewModels;

public class SensorViewModel
{
    private readonly Sensor _senor;
    
    public string Id => _senor.Id.ToString();
    public string Type => _senor.Type;
    public string Keys => _senor.Keys;
    public string SensorType => _senor.SensorType;
    public string ConnectionType => _senor.ConnectionType;

    public SensorViewModel(Sensor sensor)
    {
        _senor = sensor;
    } 
}