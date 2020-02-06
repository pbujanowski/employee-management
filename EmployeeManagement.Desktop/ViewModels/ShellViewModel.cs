using EmployeeManagement.Core.Dtos;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        //private readonly IDialogService dialogService;
        private string title = "Zarządzanie kadrą pracowniczą";

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

        public ICommand LoginOrLogoutCommand { get; private set; }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public string CurrentUserInfo
        {
            get
            {
                if (Session.User != null)
                    return "Zalogowano";
                else
                    return "Nie zalogowano";
            }
        }

        private void LoginOrLogout(object parameter)
        {
            Session.User = new UserDto();
            NotifyPropertyChanged(nameof(LoginOrLogoutButtonCaption));
            NotifyPropertyChanged(nameof(CurrentUserInfo));
        }

        public ShellViewModel()
        {
            LoginOrLogoutCommand = new RelayCommand<object>(LoginOrLogout);
        }
    }
}