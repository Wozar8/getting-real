using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class RegisterSensorViewModel : ViewModelBase
{
    private string _sensorType;

    public string SensorType
    {
        get => _sensorType;
        set
        {
            _sensorType = value;
            OnPropertyChanged(nameof(SensorType));
        }
    }

    private string _connectionType;

    public string ConnectionType
    {
        get => _connectionType;
        set
        {
            _connectionType = value;
            OnPropertyChanged(nameof(ConnectionType));
        }
    }

    private string _keys;

    public string Keys
    {
        get => _keys;
        set
        {
            _keys = value;
            OnPropertyChanged(nameof(Keys));
        }
    }

    private string _type;

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

    public RegisterSensorViewModel(SensorRepository repository)
    {
        AddCommand = new RegisterSensorCommand(repository, this);
    }
}