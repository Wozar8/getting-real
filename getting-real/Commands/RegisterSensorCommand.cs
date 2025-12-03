using System;
using System.ComponentModel;
using System.Windows;
using getting_real_4.Models;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;

namespace getting_real_4.Commands;

public class RegisterSensorCommand : CommandBase
{
    private readonly Action _afterAddAction;
    private readonly RegisterSensorViewModel _registerSensorViewModel;
    private readonly SensorRepository _repository;

    public RegisterSensorCommand(SensorRepository repository, RegisterSensorViewModel registerSensorViewModel,
        Action afterAddAction)
    {
        _repository = repository;
        _registerSensorViewModel = registerSensorViewModel;
        _afterAddAction = afterAddAction;
        _registerSensorViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RegisterSensorViewModel.Type)) OnCanExecuteChanged();
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(_registerSensorViewModel.Type) && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        var sensor = new Sensor(_registerSensorViewModel.Type, _registerSensorViewModel.Keys,
            _registerSensorViewModel.SensorType, _registerSensorViewModel.ConnectionType, _registerSensorViewModel.IsHome);
        _repository.AddSensor(sensor);
        _afterAddAction?.Invoke();

        MessageBox.Show("Sensor registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}