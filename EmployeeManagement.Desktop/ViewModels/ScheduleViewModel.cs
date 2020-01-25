using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private readonly IScheduleService<ScheduleEntry> scheduleService = new ScheduleService();
        private ObservableCollection<ScheduleEntry> scheduleEntries;
        private ScheduleEntry selectedEntry;

        public ObservableCollection<ScheduleEntry> ScheduleEntries
        {
            get { return scheduleEntries; }
            set
            {
                scheduleEntries = value;
                NotifyPropertyChanged(nameof(ScheduleEntries));
            }
        }

        public ScheduleEntry SelectedEntry
        {
            get { return selectedEntry; }
            set 
            {
                selectedEntry = value;
                NotifyPropertyChanged(nameof(SelectedEntry));
            }
        }
    }
}
