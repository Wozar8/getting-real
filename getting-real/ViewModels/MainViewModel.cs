using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(SensorRepository repository)
    {
        CurrentViewModel = new RegisterSensorViewModel(repository);
        //CurrentViewModel = new SensorListingViewModel();
    }

    public ViewModelBase CurrentViewModel { get; }
}