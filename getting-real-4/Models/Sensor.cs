namespace getting_real_4.Models;

public class Sensor
{
    public Sensor(string type, string keys, string sensorType, string connectionType)
    {
        Id = Guid.NewGuid();
        Type = type;
        Keys = keys;
        SensorType = sensorType;
        ConnectionType = connectionType;
    }

    public Guid Id { get; }
    public string Type { get; set; }
    public string Keys { get; set; }
    public string SensorType { get; set; }
    public string ConnectionType { get; set; }
}