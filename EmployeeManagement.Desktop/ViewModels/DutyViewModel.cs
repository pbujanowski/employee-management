using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Enums;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class DutyViewModel : ViewModelBase
    {
        private IDutyService<Duty> dutyService = new DutyService();
        private IEmployeeService<Employee> employeeService = new EmployeeService();
        private Duty duty = new Duty();
        private bool canDeadline;
        private string info;
        private DataMode dataMode;

        public string Info 
        {
            get { return info; }
            set
            {
                info = value;
                NotifyPropertyChanged(nameof(Info));
            }
        }

        public string Description
        {
            get { return duty.Description; }
            set
            {
                duty.Description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        public Employee ExecutiveEmployee
        {
            get { return duty.ExecutiveEmployee; }
            set
            {
                duty.ExecutiveEmployee = value;
                NotifyPropertyChanged(nameof(ExecutiveEmployee));
            }
        }

        public ObservableCollection<Employee> Employees { get; private set; }

        public DateTime OrderDate
        {
            get { return duty.OrderDate; }
            set
            {
                duty.OrderDate = value;
            }
        }

        public DateTime? Deadline
        {
            get { return duty.Deadline; }
            set
            {
                duty.Deadline = value;
                NotifyPropertyChanged(nameof(Deadline));
            }
        }

        public bool CanDeadline
        {
            get { return canDeadline; }
            set
            {
                canDeadline = value;
                NotifyPropertyChanged(nameof(CanDeadline));
            }
        }

        public ICommand GetEmployeesCommand { get; private set; }

        public ICommand AcceptDutyCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public bool CanAcceptDutyCommand(bool parameter)
        {
            return true;
        }

        public bool CanCloseCommand { get { return true; } }

        private void SetAddMode()
        {
            Title = "Dodaj obowiązek";
            dataMode = DataMode.Add;
        }

        private void SetEditMode(Duty duty)
        {
            Title = "Edytuj obowiązek";
            dataMode = DataMode.Edit;
            this.duty = duty;
        }

        private async void GetEmployees(object parameter)
        {
            try
            {
                Info = "Proszę czekać...";

                var employees = await employeeService.GetAllAsync();
                if (this.Employees == null)
                    this.Employees = new ObservableCollection<Employee>();
                else
                    this.Employees.Clear();

                foreach (var employee in employees)
                    this.Employees.Add(employee);

                ExecutiveEmployee = Employees.First();

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageService.ShowError(ex.Message);
            }
        }

        private async void AcceptDuty(object parameter)
        {
            try
            {
                Info = "Proszę czekać...";

                switch (dataMode)
                {
                    case DataMode.Add:
                        await dutyService.AddOneAsync(duty);
                        CloseCommand.Execute(null);
                        break;
                    case DataMode.Edit:
                        await dutyService.UpdateOneAsync(duty);
                        CloseCommand.Execute(null);
                        break;
                }
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageService.ShowError(ex.Message);
            }
        }

        private void Close(object parameter)
        {
            viewService.CloseDialog(nameof(DutyViewModel));
        }

        private void Initialize()
        {
            GetEmployeesCommand = new RelayCommand<object>(GetEmployees);
            AcceptDutyCommand = new RelayCommand<object>(AcceptDuty);
            CloseCommand = new RelayCommand<object>(Close);
        }

        public DutyViewModel()
        {
            Initialize();
            SetAddMode();
        }

        public DutyViewModel(Duty duty)
        {
            Initialize();
            SetEditMode(duty);
        }
    }
}