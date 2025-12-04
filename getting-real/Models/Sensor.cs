namespace getting_real_4.Models;

public class Sensor
{
    public Sensor(string type, string keys, string sensorType, string connectionType, bool isHome)
    {
        // Id will be assigned by the repository when adding the sensor
        Id = 0;
        Type = type;
        Keys = keys;
        SensorType = sensorType;
        ConnectionType = connectionType;
        BatteryReplacementCount = 0;
        IsHome = isHome;
    }

    public int Id { get; set; }
    public string Type { get; set; }
    public string Keys { get; set; }
    public string SensorType { get; set; }
    public string ConnectionType { get; set; }
    public bool IsHome { get; set; }

    // Number of times the battery has been replaced for this sensor
    public int BatteryReplacementCount { get; set; }

    public void ReplaceBattery()
    {
        BatteryReplacementCount++;
    }
}
