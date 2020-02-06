namespace EmployeeManagement.Desktop.Services
{
    public interface IViewService
    {
        void ShowDialog(string viewModelName);

        void ShowDialog(string viewModelName, object parameter);

        void CloseDialog(string viewModelName);
    }
}