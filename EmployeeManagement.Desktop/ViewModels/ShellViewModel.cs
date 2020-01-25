using System.Windows;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        //private readonly IDialogService dialogService;
        private string title = "Zarządzanie kadrą pracowniczą";

        public ICommand ShowLoginViewCommand { get; private set; }

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
                if (App.CurrentUser != null)
                    return $"Witaj, {App.CurrentUser.Id}!";
                else
                    return "Niezalogowano";
            }
        }

        private void ShowLoginView(object parameter)
        {
            //dialogService.ShowDialog("LoginView", null, null);
        }

        public ShellViewModel()
        {
            ShowLoginViewCommand = new RelayCommand<object>(ShowLoginView);
        }
    }
}
