using getting_real_4.Models.Repositories;
using getting_real_4.Services;
using getting_real_4.Stores;
using getting_real_4.ViewModels;

namespace getting_real_4.Commands;

public class NavigateCommand : CommandBase
{
    private readonly NavigationService _navigationService;

    public NavigateCommand(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}