namespace getting_real_4.Models;

public class Battery
{
	public Battery(DateTime registerDate, string batterType, double maxCapacity)
	{
		RegisterDate = registerDate;
		BatteryType = batterType;
		MaxCapacity = maxCapacity;
	}
	public string BatteryType { get; set; }
	public double MaxCapacity { get; set; }
	public DateTime RegisterDate { get; set; }
}