using CookMaster1.Views;

namespace CookMaster1.Services
{
    public class WindowService : IWindowService
    {
        public void ShowRegistrationWindow()
        {
            var w = new RegistrationWindow();
            w.ShowDialog();
        }
    }
}
