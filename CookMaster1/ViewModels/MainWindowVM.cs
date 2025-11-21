using CookMaster1.Services;

namespace CookMaster1.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        private readonly IWindowService _windowService;

        private readonly UserManager _userManager;

        // Binding for username written in the textbox

        public string Username { get; set; }

        // Binding for password

        public string Password { get; set; }

        // Button commands

        public RelayCommand LoginCommand { get; }

        public RelayCommand OpenRegisterCommand { get; }

        // Provide a parameterless constructor for XAML, forward to main ctor with default services.
        public MainWindowVM() : this(new WindowService(), new UserManager()) { }

        // Constructor used in unit tests where you can inject mocks.
        public MainWindowVM(IWindowService windowService, UserManager userManager)
        {
            _windowService = windowService;
            _userManager = userManager;
            LoginCommand = new RelayCommand(Login);
            OpenRegisterCommand = new RelayCommand(OpenRegister);
        }

        private void OpenRegister()
        {
            // Now calls service instead of creating a view directly.
            _windowService.ShowRegistrationWindow();
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





    }
}
