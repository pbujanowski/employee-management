using EmployeeManagement.Desktop.Services;
using System.ComponentModel;

namespace EmployeeManagement.Desktop.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        protected readonly IViewService viewService = ViewService.Instance;

        protected bool isBusy;

        protected string title;

        public string Error => null;

        public virtual string Title 
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                NotifyPropertyChanged(nameof(IsBusy));
            }
        }

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