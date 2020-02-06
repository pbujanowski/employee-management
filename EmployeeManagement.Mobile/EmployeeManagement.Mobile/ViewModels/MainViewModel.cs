using EmployeeManagement.Mobile.Communication;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

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