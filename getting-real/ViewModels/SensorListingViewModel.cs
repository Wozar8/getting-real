using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class SensorListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<SensorViewModel> _sensors;
    public ObservableCollection<SensorViewModel> Sensors => _sensors;
    private readonly SensorRepository _repository;
    public ICommand AddSensorCommand { get; }

    public event EventHandler? AddSensorRequested;

    public SensorListingViewModel(SensorRepository repository)
    {
        _sensors = new ObservableCollection<SensorViewModel>();
        _repository = repository;

        AddSensorCommand = new NavigateCommand(() => AddSensorRequested?.Invoke(this, EventArgs.Empty));

        UpdateRegisteredSensors();
    }

    private void UpdateRegisteredSensors()
    {
        _sensors.Clear();

        foreach (var sensor in _repository.GetAllSensors())
        {
            SensorViewModel sensorViewModel = new SensorViewModel(sensor);
            _sensors.Add(sensorViewModel);
        }
    }
}