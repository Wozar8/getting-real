namespace getting_real_4.Models.Repositories.Interfaces;

public interface ISensorRepository
{
    void AddSensor(Sensor sensor);
    Sensor GetSensorById(int id);
    List<Sensor> GetAllSensors();
    void UpdateSensor(Sensor sensor);
    void DeleteSensor(int id);
    // void Load(); // Hvad vi manglede :)))))
    // void Save();
}
