using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Desktop.Services;
using System;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public string LoginOrLogoutButtonCaption
        {
            get
            {
                if (Session.User != null)
                    return "Wyloguj się";
                else
                    return "Zaloguj się";
            }
        }

        public bool CanNavigate { get { return Session.User != null; } }

        public ICommand LoginOrLogoutCommand { get; private set; }

        public string CurrentUserInfo
        {
            get
            {
                if (Session.User != null)
                    return $"Witaj, {Session.User.Employee.FullName}";
                else
                    return "Nie zalogowano";
            }
        }

        private void LoginOrLogout(object parameter)
        {
            try
            {
                if (Session.User == null)
                {
                    viewService.ShowDialog(nameof(LoginViewModel));
                }
                else
                {
                    Session.User = null;
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                NotifyPropertyChanged(nameof(LoginOrLogoutButtonCaption));
                NotifyPropertyChanged(nameof(CurrentUserInfo));
                NotifyPropertyChanged(nameof(CanNavigate));
            }
        }

        public ShellViewModel()
        {
            Title = "Zarządzanie kadrą pracowniczą";
            LoginOrLogoutCommand = new RelayCommand<object>(LoginOrLogout);
        }
    }
}