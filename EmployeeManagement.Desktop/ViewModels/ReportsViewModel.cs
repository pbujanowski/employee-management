using EmployeeManagement.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private ObservableCollection<Report> reports;
        private Report selectedReport;

        public ObservableCollection<Report> Reports
        {
            get { return reports; }
            set
            {
                reports = value;
                NotifyPropertyChanged(nameof(Reports));
            }
        }

        public Report SelectedReport
        {
            get { return selectedReport; }
            set
            {
                selectedReport = value;
                NotifyPropertyChanged(nameof(SelectedReport));
            }
        }

        public ICommand AddReportCommand { get; }

        public ICommand RefreshReportsListCommand { get; }

        private void AddReport(object parameter)
        {
        }

        private void RefreshReportsList(object parameter)
        {
        }

        public ReportsViewModel()
        {
            AddReportCommand = new RelayCommand<object>(AddReport);
            RefreshReportsListCommand = new RelayCommand<object>(RefreshReportsList);
        }
    }
}