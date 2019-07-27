using EmployeeManagement.Core.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private List<Employee> presentEmployees;

        public List<Employee> PresentEmployees
        {
            get { return presentEmployees; }
            set { SetProperty(ref presentEmployees, value); }
        }
    }
}
