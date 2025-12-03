using System.ComponentModel;

namespace getting_real_4.ViewModels;

// Base class that helps all ViewModels notify the UI when values change.
// This is a common pattern in WPF called INotifyPropertyChanged.
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    // Call this whenever a property value changes so bindings update.
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}