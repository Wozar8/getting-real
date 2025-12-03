using System.ComponentModel;
using System.Windows;
using getting_real_4.Models;
using getting_real_4.Models.Repositories;
using getting_real_4.ViewModels;

namespace getting_real_4.Commands;

public class RegisterSensorCommand : CommandBase
{
    // After we add a sensor, invoke provided callback to go back to the list.
    private readonly Action _onAfterAdd;
    private readonly RegisterSensorViewModel _registerSensorViewModel;
    private readonly SensorRepository _repository;

    public RegisterSensorCommand(SensorRepository repository, RegisterSensorViewModel registerSensorViewModel,
        Action afterAddAction)
    {
        _repository = repository;
        _registerSensorViewModel = registerSensorViewModel;
        _onAfterAdd = afterAddAction;
        // Watch for changes in the Type field to enable/disable the Add button.
        _registerSensorViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(RegisterSensorViewModel.Type)) OnCanExecuteChanged();
    }

    // Only allow Add when the Type field has a value.
    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(_registerSensorViewModel.Type) && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        // Create a new sensor from the form fields.
        var sensor = new Sensor(_registerSensorViewModel.Type, _registerSensorViewModel.Keys,
            _registerSensorViewModel.SensorType, _registerSensorViewModel.ConnectionType, _registerSensorViewModel.IsHome);
        // Save it using the repository.
        _repository.AddSensor(sensor);
        // Tell the window to go back to the list.
        _onAfterAdd?.Invoke();

        // Give simple feedback to the user.
        MessageBox.Show("Sensor registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}