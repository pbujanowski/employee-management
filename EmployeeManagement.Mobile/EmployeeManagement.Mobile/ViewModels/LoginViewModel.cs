using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Mobile.Communication;
using EmployeeManagement.Mobile.Services;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService<UserDto, AuthenticationDto> userService = DependencyService.Get<IUserService<UserDto, AuthenticationDto>>();
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
                Info = "Proszę czekać...";

                var auth = new AuthenticationDto { Username = UserName, Password = Password };
                var user = await userService.LoginAsync(auth);
                if (user != null)
                {
                    Session.User = user;
                    Info = "Zalogowano";
                    MessagingCenter.Send(this, Message.CloseLoginPage);
                }
                else
                    throw new Exception("Wprowadzono nieprawidłowe dane!");
            }
            catch (Exception ex)
            {
                MessageService.DisplayAlert(this, ex.Message);
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