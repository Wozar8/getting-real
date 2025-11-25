using getting_real_4.Models;
using getting_real_4.Models.Repositories;

namespace getting_real_4.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel(SensorRepository repository)
    {
        CurrentViewModel = new RegisterSensorViewModel(repository);
        //CurrentViewModel = new SensorListingViewModel();
    }
}