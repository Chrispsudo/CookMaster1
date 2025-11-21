namespace CookMaster1.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        private readonly UserManager _userManager;

        // Binding for username written in the textbox

        public string Username { get; set; }

        // Binding for password

        public string Password { get; set; }

        // Button commands

        public RelayCommand LoginCommand { get; }

        public RelayCommand OpenRegisterCommand { get; }

        public MainWindowWM()
        {
            _userManager = new UserManager();

            // Connect buttons in XAML to methods

            LoginCommand = new RelayCommand(Login);

            OpenRegisterCommand = new RelayCommand(OpenRegister);

        }

        private void Login()
        {
            // Call UserManager to handle login logic
            bool success = _userManager.Login(Username, Password);
            if (success)
            {
                // Handle successful login (e.g., navigate to main app window)
            }
            else
            {
                // Handle failed login (e.g., show error message)
            }
        }

        private void OpenRegister()
        {
            // Logic to open the registration window
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
        }




    }
}
