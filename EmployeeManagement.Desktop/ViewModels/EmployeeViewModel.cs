using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Desktop.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class EmployeeViewModel : DialogViewModelBase
    {
        private Employee employee;
        private readonly IEmployeeService<Employee> employeeService;
        private DataMode dataMode;

        public string FirstName
        {
            get { return employee.FirstName; }
            set
            {
                employee.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return employee.LastName; }
            set
            {
                employee.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public string Job
        {
            get { return employee.Job; }
            set
            {
                employee.Job = value;
                RaisePropertyChanged(nameof(Job));
            }
        }

        public bool CanJob { get { return false; } }

        public List<string> Jobs { get; private set; }

        public DateTime EmploymentDate
        {
            get { return employee.EmploymentDate; }
            set
            {
                employee.EmploymentDate = value;
                RaisePropertyChanged(nameof(EmploymentDate));
            }
        }

        public ICommand AcceptEmployeeCommand { get; set; }

        public ICommand CancelEmployeeCommand { get; set; }

        private async void ExecuteAcceptEmployee()
        {
            switch (dataMode)
            {
                case DataMode.Add:
                    await employeeService.AddOneAsync(employee);
                    break;
                case DataMode.Edit:
                    await employeeService.UpdateOneAsync(employee);
                    break;
            }
        }

        private void ExecuteCancelEmployee()
        {
            RaiseRequestClose(new DialogResult());
        }

        private void SetAddMode()
        {
            Title = "Dodaj pracownika";
            dataMode = DataMode.Add;
        }

        private void SetEditMode(Employee employee)
        {
            Title = "Edytuj pracownika";
            dataMode = DataMode.Edit;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Job = employee.Job;
            EmploymentDate = employee.EmploymentDate;
        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            Jobs = await employeeService.GetAllJobsAsync();
            switch (parameters.GetValue<DataMode>("DataMode"))
            {
                case DataMode.Add:
                    SetAddMode();
                    break;
                case DataMode.Edit:
                    SetEditMode(parameters.GetValue<Employee>("Employee"));
                    break;
                default:
                    throw new ArgumentException("Przekazano nieprawidłowy parametr trybu danych!");
            }
        }

        public override void OnDialogClosed()
        {
            base.OnDialogClosed();
        }

        public EmployeeViewModel(IEmployeeService<Employee> employeeService)
        {
            this.employeeService = employeeService;
            this.employee = new Employee();
            AcceptEmployeeCommand = new DelegateCommand(ExecuteAcceptEmployee);
            CancelEmployeeCommand = new DelegateCommand(ExecuteCancelEmployee);
        }
    }
}
