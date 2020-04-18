using EmployeeManagement.Mobile.Communication;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public string Status 
        {
            get
            {
                if (Session.User == null)
                    return "Nie zalogowano";
                else
                    return $"Witaj, {Session.User.Username}";
            }
        }

        private void ExecuteLoginCommand()
        {
            MessagingCenter.Send(this, Message.OpenLoginPage);
        }

        public MainViewModel()
        {
            Title = "Strona główna";
            LoginCommand = new Command(() => ExecuteLoginCommand());
        }
    }
}