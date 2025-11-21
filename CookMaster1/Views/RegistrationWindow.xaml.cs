using System.Windows;
using System.Windows.Controls;

namespace CookMaster1.Views
{
    /// <summary>
    /// Code-behind for the simple registration window.
    /// This quick implementation directly handles the button clicks.
    /// For a more MVVM-friendly approach, create a RegistrationViewModel later.
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        // Handler for the Register button - very simple placeholder logic
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            string country = CountryBox.Text;

            // Very simple validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please provide both username and password.");
                return;
            }

            // TODO: call UserManager.Register(username, password, country)
            MessageBox.Show($"Would register: {username} ({country})");

            // Close the window after "registration"
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
