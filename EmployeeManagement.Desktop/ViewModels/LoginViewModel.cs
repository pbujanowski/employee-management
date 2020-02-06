using System;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //private readonly IUserService<User> userService;
        private string userName;

        private string password;
        private string errorMessage;

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

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        private async void Login()
        {
            try
            {
                //var user = await userService.LoginAsync(new User { UserName = UserName, Password = Password }); ;
                //if (user != null)
                //{
                //    App.CurrentUser = user;
                //    //RaiseRequestClose(new DialogResult());
                //}
                //else
                //    ErrorMessage = "Wprowadzone dane są nieprawidłowe!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel()
        {
            Application.Current.Shutdown();
        }
    }
}