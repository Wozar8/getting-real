using System.Windows.Input;

namespace getting_real_4.ViewModels;

public class RegisterSensorViewModel : ViewModelBase
{
    private string _sensorType;
    private string _connectionType;
    private string _keys;
    private string _type;

    public string SensorType
    {
        get => _sensorType;
        set => OnPropertyChanged(SensorType);
    }

    public string ConnectionType
    {
        get => _connectionType;
        set => OnPropertyChanged(ConnectionType);
    }

    public string Keys
    {
        get => _keys;
        set => OnPropertyChanged(Keys);
    }

    public string Type
    {
        get => _type;
        set => OnPropertyChanged(Type);
    }

    public ICommand AddCommand { get; }
    public ICommand CancelCommand { get; }
}