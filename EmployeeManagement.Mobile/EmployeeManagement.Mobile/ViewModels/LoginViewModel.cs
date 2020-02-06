using EmployeeManagement.Mobile.Communication;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string userName;
        private string password;
        private string info;

        public string UserName
        {
            get { return userName; }
            set
            {
                SetProperty(ref userName, value);
                LoginCommand.ChangeCanExecute();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                SetProperty(ref password, value);
                LoginCommand.ChangeCanExecute();
            }
        }

        public string Info
        {
            get { return info; }
            set { SetProperty(ref info, value); }
        }

        public Command LoginCommand { get; }

        private async Task ExecuteLoginCommand()
        {
            try
            {
                await Task.CompletedTask;
                Info = "Zalogowano";
                MessagingCenter.Send<LoginViewModel>(this, Message.CloseLoginPage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Info = "Błąd!";
            }
        }

        private bool CanExecuteLoginCommand
        {
            get
            {
                return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
            }
        }

        public LoginViewModel()
        {
            Title = "Logowanie";
            LoginCommand = new Command(async () => await ExecuteLoginCommand(), () => CanExecuteLoginCommand);
        }
    }
}