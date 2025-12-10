using getting_real_4.Models;
using getting_real_4.Models.Repositories;

namespace getting_real_test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void AddSensor_IncreasesRepositoryCount()
        {
            // Arrange
            SensorRepository repo = new SensorRepository();

			// Act
			int initialCount = repo.GetAllSensors().Count();
			Sensor sensor = new Sensor("DHT-LoRa", "Key123", "ultralyd", "LoRaWan", true);
            repo.AddSensor(sensor);

            // Assert
            int newCount = repo.GetAllSensors().Count();
            Assert.AreEqual(initialCount + 1, newCount);
        }
    }
}
