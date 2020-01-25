using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ReportTemplatesViewModel : ViewModelBase
    {
        private readonly IViewService viewService = ViewService.Instance;
        private ObservableCollection<ReportTemplate> reportTemplates;
        private ReportTemplate selectedTemplate;

        public ObservableCollection<ReportTemplate> ReportTemplates 
        {
            get { return reportTemplates; }
            set
            {
                reportTemplates = value;
                NotifyPropertyChanged(nameof(ReportTemplates));
            }
        }

        public ReportTemplate SelectedTemplate 
        {
            get { return selectedTemplate; }
            set
            {
                selectedTemplate = value;
                NotifyPropertyChanged(nameof(SelectedTemplate));
            }
        }

        public ICommand AddReportTemplateCommand { get; set; }

        public ICommand RefreshReportTemplatesListCommand { get; set; }

        private void AddReportTemplate(object parameter)
        {
            viewService.ShowDialog(nameof(ReportTemplateDesignerViewModel));
        }

        private void RefreshReportTemplatesList(object parameter)
        {

        }

        public ReportTemplatesViewModel()
        {
            AddReportTemplateCommand = new RelayCommand<object>(AddReportTemplate);
            RefreshReportTemplatesListCommand = new RelayCommand<object>(RefreshReportTemplatesList);
        }
    }
}
