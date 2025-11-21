using CookMaster1.ViewModels; // Import required for accessing MainWindowVM
using System.Windows;
using System.Windows.Controls;

namespace CookMaster1.Views
{
    /// <summary>
    /// Code-behind for MainWindow.xaml.
    /// Handles UI events that cannot be bound directly in MVVM (e.g., PasswordBox).
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Loads the XAML layout and applies DataContext

            // Set the DataContext here in code-behind instead of XAML.
            // This avoids design-time errors when the ViewModel needs services or types
            // that the XAML designer cannot instantiate.
            this.DataContext = new CookMaster1.ViewModels.MainWindowVM();
        }

        /// <summary>
        /// This event fires every time the user types in the PasswordBox.
        /// Because PasswordBox does not support direct binding to a string,
        /// we manually forward the password value into the ViewModel.
        /// </summary>
        private void PwBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Safely get the ViewModel instance (DataContext)
            if (this.DataContext is MainWindowVM vm)
            {
                // Transfer the password from UI to ViewModel
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}

