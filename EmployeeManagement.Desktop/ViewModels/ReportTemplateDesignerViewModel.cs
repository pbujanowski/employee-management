using EmployeeManagement.Core.Models;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ReportTemplateDesignerViewModel : ViewModelBase
    {
        private readonly ReportTemplate template = new ReportTemplate();
        private string previewValue;

        public string Code
        {
            get { return template.Code; }
            set
            {
                template.Code = value;
                NotifyPropertyChanged(nameof(Code));
            }
        }

        public string Value
        {
            get { return template.Value; }
            set
            {
                template.Value = value;
                NotifyPropertyChanged(nameof(Value));
            }
        }

        public string PreviewValue
        {
            get { return previewValue; }
            set
            {
                previewValue = value;
                NotifyPropertyChanged(nameof(PreviewValue));
            }
        }

        public ICommand RefreshReportPreviewCommand { get; set; }

        private void RefreshReportPreview(object parameter)
        {
            PreviewValue = Value;
        }

        public ReportTemplateDesignerViewModel()
        {
            RefreshReportPreviewCommand = new RelayCommand<object>(RefreshReportPreview);
            Value = "<html><head></head><body><p>hello!</p></body></html>";
        }
    }
}