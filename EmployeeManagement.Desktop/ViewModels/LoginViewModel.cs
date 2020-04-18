using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserService<UserDto, AuthenticationDto> userService = new UserService();
        private string userName;

        private string password;
        private string info;

        public override string Title => "Logowanie";

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                NotifyPropertyChanged(nameof(Info));
            }
        }

        public ICommand LoginCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public bool CanLogin { get { return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password); } }

        private async void Login(object parameter)
        {
            try
            {
                Info = "Proszę czekać...";

                var user = await userService.LoginAsync(new AuthenticationDto { Username = UserName, Password = Password });
                if (user != null)
                {
                    Session.User = user;
                    CloseCommand.Execute(null);
                }
                else
                    Info = "Wprowadzone dane są nieprawidłowe!";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Close(object parameter)
        {
            viewService.CloseDialog(nameof(LoginViewModel));
        }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>(Login);
            CloseCommand = new RelayCommand<object>(Close);
        }
    }
}