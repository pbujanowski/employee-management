using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ScheduleEntryViewModel : ViewModelBase
    {
        private readonly IScheduleService<ScheduleEntry> scheduleService = new ScheduleService();
        private readonly ScheduleEntry scheduleEntry = new ScheduleEntry();

        public Employee SelectedEmployee
        {
            get { return scheduleEntry.Employee; }
            set
            {
                scheduleEntry.Employee = value;
                NotifyPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public DateTime? Start
        {
            get { return scheduleEntry.Start; }
            set
            {
                scheduleEntry.Start = value;
                NotifyPropertyChanged(nameof(Start));
            }
        }

        public DateTime? End
        {
            get { return scheduleEntry.End; }
            set
            {
                scheduleEntry.End = value;
                NotifyPropertyChanged(nameof(End));
            }
        }

        public ICommand AddScheduleEntryCommand { get; }

        private async void AddScheduleEntry(object parameter)
        {
        }

        public ScheduleEntryViewModel()
        {
            AddScheduleEntryCommand = new RelayCommand<object>(AddScheduleEntry);
        }
    }
}