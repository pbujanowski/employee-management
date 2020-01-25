using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private List<Employee> presentEmployees;

        public List<Employee> PresentEmployees
        {
            get { return presentEmployees; }
            set 
            {
                presentEmployees = value;
                NotifyPropertyChanged(nameof(PresentEmployees));
            }
        }
    }
}
