namespace getting_real_4.Models.Repositories.Interfaces;

public interface ISensorRepository
{
    void AddSensor(Sensor sensor);
    Sensor GetSensorById(int id);
    IEnumerable<Sensor> GetAllSensors();
    void UpdateSensor(Sensor sensor);
    void DeleteSensor(int id);
}