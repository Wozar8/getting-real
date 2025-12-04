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
            var repo = new SensorRepository();
            var initialCount = repo.GetAllSensors().Count();

            // Act
            var sensor = new Sensor("DHT-LoRa", "Key123", "ultralyd", "LoRaWan", true);
            repo.AddSensor(sensor);

            // Assert
            var newCount = repo.GetAllSensors().Count();
            Assert.AreEqual(initialCount + 1, newCount);
        }
    }
}
