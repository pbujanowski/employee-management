using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Enums;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        private readonly IEmployeeService<Employee> employeeService = new EmployeeService();
        private readonly IViewService viewService = ViewService.Instance;
        private ObservableCollection<Employee> employees;
        private Employee selectedEmployee;
        //private readonly IDialogService dialogService;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set 
            {
                employees = value;
                NotifyPropertyChanged(nameof(Employees));
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                NotifyPropertyChanged(nameof(SelectedEmployee));
                NotifyPropertyChanged(nameof(CanEditEmployee));
            }
        }

        public ICommand RefreshEmployeesListCommand { get; }

        public ICommand AddEmployeeCommand { get; }

        public ICommand EditEmployeeCommand { get; }

        public bool CanEditEmployee { get { return SelectedEmployee != null; } }

        private async void RefreshEmployeesList(object parameter)
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

        private void AddEmployee(object parameter)
        {
            //var parameters = new DialogParameters
            //{
            //    { "DataMode", DataMode.Add }
            //};
            //dialogService.ShowDialog("EmployeeView", parameters, RefreshEmployeesListCommand.Execute);
            viewService.ShowDialog(nameof(EmployeeViewModel));
        }

        private void EditEmployee(object parameter)
        {
            //if (SelectedEmployee != null)
            //{
            //    var parameters = new DialogParameters
            //    {
            //        { "DataMode", DataMode.Edit },
            //        { "Employee", SelectedEmployee }
            //    };
            //    dialogService.ShowDialog("EmployeeView", parameters, RefreshEmployeesListCommand.Execute);
            //}
            //else
            //    MessageBox.Show("Nie wybrano żadnego pracownika!");
        }

        public EmployeesViewModel()
        {
            //this.dialogService = dialogService;
            RefreshEmployeesListCommand = new RelayCommand<object>(RefreshEmployeesList);
            AddEmployeeCommand = new RelayCommand<object>(AddEmployee);
            EditEmployeeCommand = new RelayCommand<object>(EditEmployee);
        }
    }
}
