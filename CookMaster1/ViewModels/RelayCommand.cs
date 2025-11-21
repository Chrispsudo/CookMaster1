using System;
using System.Windows.Input;

namespace CookMaster1.ViewModels
{
    // Makes it possible to bind commands in the ViewModel to UI elements in the View
    public class RelayCommand : ICommand
    {
        private readonly Action_execute; // Action to execute

        private readonly Func<bool> _canExecute; // Function to determine if the command can execute

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Will the button be clickable?
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        // What happens when the button is clicked
        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
