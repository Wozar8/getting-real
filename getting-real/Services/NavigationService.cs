using getting_real_4.Stores;
using getting_real_4.ViewModels;

namespace getting_real_4.Services;

public class NavigationService
{
    private readonly Func<ViewModelBase> _createViewModel;
    private readonly NavigationStore _navigationStore;

    public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }


    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}