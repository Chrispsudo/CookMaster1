using System.ComponentModel;

namespace CookMaster1.ViewModels
{
    // All viewmodels will inherit from this base class to use PropertyChanged functionality
    public class BaseViewModel : INotifyPropertyChanged
    {
        // This event is triggered whenever a property value changes

        public event PropertyChangedEventHandler PropertyChanged;

        // Help method to trigger the PropertyChanged event

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
