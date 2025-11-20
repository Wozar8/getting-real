namespace getting_real_4.Models.Repositories.Interfaces;

public interface ISensorRepository
{
    void AddSensor(Sensor sensor);
    Sensor GetSensorById(Guid id);
    IEnumerable<Sensor> GetAllSensors();
    void UpdateSensor(Sensor sensor);
    void DeleteSensor(Guid id);
}