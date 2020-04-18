using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System.Collections.ObjectModel;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private readonly IScheduleService<ScheduleEntry> scheduleService = new ScheduleService();
        private ObservableCollection<ScheduleEntry> scheduleEntries;
        private ScheduleEntry selectedEntry;

        public override string Title => "Harmonogram";

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