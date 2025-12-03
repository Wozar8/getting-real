using System;

namespace getting_real_4.Commands;

public class NavigateCommand : CommandBase
{
    private readonly Action _navigateAction;

    public NavigateCommand(Action navigateAction)
    {
        _navigateAction = navigateAction;
    }

    public override void Execute(object? parameter)
    {
        _navigateAction?.Invoke();
    }
}