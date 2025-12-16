// The repository and repo interface folders could be moved into ViewModels folder

using System.Diagnostics;
using System.IO;
using getting_real_4.Models.Repositories.Interfaces;

namespace getting_real_4.Models.Repositories;

public class SensorRepository : ISensorRepository
{
    private readonly List<Sensor> _sensors = new();
    private const string dataFile = "sensors.csv";
    private int _nextId = 1;

    public void AddSensor(Sensor sensor)
    {
        // Assign a new incremental ID
        sensor.Id = _nextId++;
        _sensors.Add(sensor);
    }

    public Sensor GetSensorById(int id)
    {
        return _sensors.FirstOrDefault(s => s.Id == id);
    }

    public List<Sensor> GetAllSensors()
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

    public void DeleteSensor(int id)
    {
        var sensor = GetSensorById(id);
        if (sensor != null) _sensors.Remove(sensor);
    }

    public void Load()
    {
        try
        {
            if (!File.Exists(dataFile))
                return;

            _sensors.Clear();
            _nextId = 1;

            using var reader = new StreamReader(dataFile);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');
                if (parts.Length != 7)
                {
                    Debug.WriteLine($"Skipping malformed line in {dataFile}: '{line}'");
                    continue;
                }

                try
                {
                    var sensor = new Sensor(
                        parts[1],  // Type
                        parts[2],  // Keys
                        parts[3],  // SensorType
                        parts[4],  // ConnectionType
                        bool.Parse(parts[6])  // InStorage
                    )
                    {
                        Id = int.Parse(parts[0]),
                        BatteryReplacementCount = int.Parse(parts[5])
                    };

                    _sensors.Add(sensor);
                    // Track next ID to avoid collisions
                    if (sensor.Id >= _nextId)
                    {
                        _nextId = sensor.Id + 1;
                    }
                }
                catch (FormatException fx)
                {
                    // Skip bad line, but log it for diagnosis
                    Debug.WriteLine($"Skipping line with parse error in {dataFile}: '{line}' ({fx.Message})");
                    continue;
                }
            }
        }
        catch (UnauthorizedAccessException uaEx)
        {
            throw new IOException($"Access denied reading '{dataFile}'.", uaEx);
        }
    }

    public void Save()
    {
        try
        {
            using var writer = new StreamWriter(dataFile);
            foreach (var sensor in _sensors)
            {
                writer.WriteLine($"{sensor.Id},{sensor.Type},{sensor.Keys},{sensor.SensorType},{sensor.ConnectionType},{sensor.BatteryReplacementCount},{sensor.InStorage}");
            }
        }
        catch (UnauthorizedAccessException uaEx)
        {
            throw new IOException($"Access denied writing '{dataFile}'.", uaEx);
        }
    }
}