using System.ComponentModel;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public string Error => null;

        public string this[string columnName] => ValidateProperty(columnName);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual string ValidateProperty(string propertyName)
        {
            return null;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}