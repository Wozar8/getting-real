using getting_real_4.Models.Repositories.Interfaces;
using System.IO;
using System.Diagnostics;

namespace getting_real_4.Models.Repositories;

public class SensorRepository : ISensorRepository
{
    private readonly List<Sensor> _sensors = new();
    private const string DataFile = "sensors.csv";

    public void AddSensor(Sensor sensor)
    {
        _sensors.Add(sensor);
    }

    public Sensor GetSensorById(Guid id)
    {
        return _sensors.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Sensor> GetAllSensors()
    {
        return _sensors;
    }

    public void UpdateSensor(Sensor sensor)
    {
        var existingSensor = GetSensorById(sensor.Id);
        if (existingSensor != null)
        {
            _sensors.Remove(existingSensor);
            _sensors.Add(sensor);
        }
    }

    public void DeleteSensor(Guid id)
    {
        var sensor = GetSensorById(id);
        if (sensor != null) _sensors.Remove(sensor);
    }

    public void Load()
    {
        try
        {
            if (!File.Exists(DataFile))
                return;

            _sensors.Clear();

            using var reader = new StreamReader(DataFile);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');
                if (parts.Length != 7)
                {
                    Debug.WriteLine($"Skipping malformed line in {DataFile}: '{line}'");
                    continue;
                }

                try
                {
                    var sensor = new Sensor(
                        parts[1],  // Type
                        parts[2],  // Keys
                        parts[3],  // SensorType
                        parts[4],  // ConnectionType
                        bool.Parse(parts[6])  // IsHome
                    )
                    {
                        Id = Guid.Parse(parts[0]),
                        BatteryReplacementCount = int.Parse(parts[5])
                    };

                    _sensors.Add(sensor);
                }
                catch (FormatException fx)
                {
                    // Skip bad line, but log it for diagnosis
                    Debug.WriteLine($"Skipping line with parse error in {DataFile}: '{line}' ({fx.Message})");
                    continue;
                }
            }
        }
        catch (UnauthorizedAccessException uaEx)
        {
            throw new IOException($"Access denied reading '{DataFile}'.", uaEx);
        }
    }

    public void Save()
    {
        try
        {
            using var writer = new StreamWriter(DataFile);
            foreach (var sensor in _sensors)
            {
                writer.WriteLine($"{sensor.Id},{sensor.Type},{sensor.Keys},{sensor.SensorType},{sensor.ConnectionType},{sensor.BatteryReplacementCount},{sensor.IsHome}");
            }
        }
        catch (UnauthorizedAccessException uaEx)
        {
            throw new IOException($"Access denied writing '{DataFile}'.", uaEx);
        }
    }
}