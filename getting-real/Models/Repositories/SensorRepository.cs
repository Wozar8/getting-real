namespace getting_real.Models.Repositories;

using getting_real.Models.Repositories.Interfaces;

public class SensorRepository : ISensorRepository
{
    private readonly List<Sensor> _sensors = new();

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
        if (sensor != null)
        {
            _sensors.Remove(sensor);
        }
    }
}