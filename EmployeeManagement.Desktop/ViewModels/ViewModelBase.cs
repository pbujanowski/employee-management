using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
