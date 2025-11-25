using getting_real_4.Models;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;

namespace getting_real_4.Commands;

public class RegisterSensorCommand : CommandBase
{
    private readonly SensorRepository _repository;
    private readonly RegisterSensorViewModel _registerSensorViewModel;

    public RegisterSensorCommand(SensorRepository repository, RegisterSensorViewModel registerSensorViewModel)
    {
        _repository = repository;
        _registerSensorViewModel = registerSensorViewModel;
    }

    public override void Execute(object? parameter)
    {
        Sensor sensor = new Sensor(_registerSensorViewModel.Type, _registerSensorViewModel.Keys,
            _registerSensorViewModel.SensorType, _registerSensorViewModel.ConnectionType);
        _repository.AddSensor(sensor);
    }
}