using System.ComponentModel;
using System.Windows;
using getting_real_4.Models;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;

namespace getting_real_4.Commands;

public class RegisterSensorCommand : CommandBase
{
    private readonly RegisterSensorViewModel _registerSensorViewModel;
    private readonly SensorRepository _repository;

    public RegisterSensorCommand(SensorRepository repository, RegisterSensorViewModel registerSensorViewModel)
    {
        _repository = repository;
        _registerSensorViewModel = registerSensorViewModel;

        _registerSensorViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RegisterSensorViewModel.Type))
        {
            OnCanExecuteChanged();
        }
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(_registerSensorViewModel.Type) && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        var sensor = new Sensor(_registerSensorViewModel.Type, _registerSensorViewModel.Keys,
            _registerSensorViewModel.SensorType, _registerSensorViewModel.ConnectionType);
        _repository.AddSensor(sensor);
    }
}