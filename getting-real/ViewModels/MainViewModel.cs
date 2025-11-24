namespace getting_real_4.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel()
    {
        CurrentViewModel = new RegisterSensorViewModel();
    }
}