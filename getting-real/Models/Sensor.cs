using System.Diagnostics;

namespace getting_real_4.Models;

// TODO: Validation is missing

public class Sensor
{
	public Sensor(string type, string keys, string sensorType, string connectionType, bool isHome)
	{
		validateSensorType(sensorType);
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

	public void validateSensorType(string sensorType)
	{
		string loweredType = sensorType.ToLower();
		if (loweredType != "ultralyd" && loweredType != "time of flight")
		{
			Debug.WriteLine($"Invalid sensor type: '{sensorType}'. Must be 'ultralyd' or 'time of flight'.");
		}
	}
}
