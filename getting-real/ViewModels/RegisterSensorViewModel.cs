using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class RegisterSensorViewModel : ViewModelBase
{
    private string _connectionType;

    private string _keys;
    private string _sensorType;

    private string _type;

    public RegisterSensorViewModel(SensorRepository repository)
    {
        AddCommand = new RegisterSensorCommand(repository, this);
    }

    public string SensorType
    {
        get => _sensorType;
        set
        {
            _sensorType = value;
            OnPropertyChanged(nameof(SensorType));
        }
    }

    public string ConnectionType
    {
        get => _connectionType;
        set
        {
            _connectionType = value;
            OnPropertyChanged(nameof(ConnectionType));
        }
    }

    public string Keys
    {
        get => _keys;
        set
        {
            _keys = value;
            OnPropertyChanged(nameof(Keys));
        }
    }

    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }


    public ICommand AddCommand { get; }
    public ICommand CancelCommand { get; }
}