using System.Windows.Input;
using getting_real_4.Commands;
using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class RegisterSensorViewModel : ViewModelBase
{
    // These are the form fields bound from the RegisterSensorView.
    private string _connectionType;
    private string _keys;
    private string _sensorType;
    private string _type;
    private bool _isHome;

    // Buttons in the view bind to these commands.
    public ICommand AddCommand { get; }
    public ICommand CancelCommand { get; }

    // Simplified navigation: single callback provided by host.
    private readonly Action _navigateBack;

    public RegisterSensorViewModel(SensorRepository repository, Action navigateBack)
    {
        _navigateBack = navigateBack;

        // When AddCommand executes, we add the sensor and then go back.
        AddCommand = new RegisterSensorCommand(repository, this, _navigateBack);
        // When CancelCommand executes, just go back without adding.
        CancelCommand = new NavigateCommand(_navigateBack);
    }

    // Each property notifies the UI when it changes so the view updates.
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

    public bool IsHome
    {
        get => _isHome;
        set
        {
            _isHome = value;
            OnPropertyChanged(nameof(IsHome));
        }
    }
}