namespace getting_real_4.Models;

public class Battery
{
    public Battery(DateTime registerDate, string batterType, double maxCapacity, string mountType)
    {
        RegisterDate = registerDate;
        BatteryType = batterType;
        MaxCapacity = maxCapacity;
        MountType = mountType;
    }

    public string BatteryType { get; set; }
    public double MaxCapacity { get; set; }
    public string MountType { get; set; }
    public DateTime RegisterDate { get; set; }
}