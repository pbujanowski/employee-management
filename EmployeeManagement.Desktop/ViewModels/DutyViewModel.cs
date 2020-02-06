using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class DutyViewModel : ViewModelBase
    {
        private IViewService viewService = ViewService.Instance;
        private IDutyService<Duty> dutyService = new DutyService();
        private Duty duty = new Duty();
        private bool canDeadline;

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

        public ICommand CancelDutyCommand { get; private set; }

        public bool CanAcceptDutyCommand(bool parameter)
        {
            return true;
        }

        public bool CanCancelDutyCommand { get { return true; } }

        private async void GetEmployees(object parameter)
        {
        }

        private async void AcceptDuty(object parameter)
        {
        }

        private void CancelDuty(object parameter)
        {
            viewService.CloseDialog(nameof(DutyViewModel));
        }

        public DutyViewModel()
        {
            GetEmployeesCommand = new RelayCommand<object>(GetEmployees);
            AcceptDutyCommand = new RelayCommand<object>(AcceptDuty);
            CancelDutyCommand = new RelayCommand<object>(CancelDuty);
        }
    }
}