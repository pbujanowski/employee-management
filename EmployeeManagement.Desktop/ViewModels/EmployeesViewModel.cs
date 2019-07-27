using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Desktop.Enums;
using EmployeeManagement.Desktop.Services;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class EmployeesViewModel : BindableBase
    {
        private readonly IEmployeeService<Employee> employeeService;
        private ObservableCollection<Employee> employees;
        private Employee selectedEmployee;
        private readonly IDialogService dialogService;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { SetProperty(ref employees, value); }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                SetProperty(ref selectedEmployee, value);
                RaisePropertyChanged(nameof(CanEditEmployee));
            }
        }

        public ICommand RefreshEmployeesListCommand { get; }

        public ICommand AddEmployeeCommand { get; }

        public ICommand EditEmployeeCommand { get; }

        public bool CanEditEmployee { get { return SelectedEmployee != null; } }

        private async void ExecuteRefreshEmployeesList()
        {
            try
            {
                if (Employees == null)
                    Employees = new ObservableCollection<Employee>();

                var employees = await employeeService.GetAllAsync().ConfigureAwait(false);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Employees.Clear();

                    foreach (var employee in employees)
                        Employees.Add(employee);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecuteAddEmployee()
        {
            var parameters = new DialogParameters
            {
                { "DataMode", DataMode.Add }
            };
            dialogService.ShowDialog("EmployeeView", parameters, RefreshEmployeesListCommand.Execute);
        }

        private void ExecuteEditEmployee()
        {
            if (SelectedEmployee != null)
            {
                var parameters = new DialogParameters
                {
                    { "DataMode", DataMode.Edit },
                    { "Employee", SelectedEmployee }
                };
                dialogService.ShowDialog("EmployeeView", parameters, RefreshEmployeesListCommand.Execute);
            }
            else
                MessageBox.Show("Nie wybrano żadnego pracownika!");
        }

        public EmployeesViewModel(IEmployeeService<Employee> employeeService, IDialogService dialogService)
        {
            this.employeeService = employeeService;
            this.dialogService = dialogService;
            RefreshEmployeesListCommand = new DelegateCommand(ExecuteRefreshEmployeesList);
            AddEmployeeCommand = new DelegateCommand(ExecuteAddEmployee);
            EditEmployeeCommand = new DelegateCommand(ExecuteEditEmployee);
        }
    }
}
