using System.Windows;
using getting_real_4.ViewModels;

namespace getting_real_4.Commands;

public class ReplaceBatteryCommand : CommandBase
{
    private readonly SensorViewModel _sensorViewModel;

    public ReplaceBatteryCommand(SensorViewModel sensorViewModel)
    {
        _sensorViewModel = sensorViewModel;
    }

    public override void Execute(object? parameter)
    {
        _sensorViewModel.ReplaceBattery();
        MessageBox.Show("Battery replaced.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
