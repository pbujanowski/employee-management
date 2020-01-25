using EmployeeManagement.Desktop.ViewModels;
using EmployeeManagement.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Desktop.Services
{
    public class ViewService : IViewService
    {
        private static readonly object locker = new object();
        private static ViewService instance;
        public static ViewService Instance { get { lock (locker) { return instance ?? (instance = new ViewService()); } } }
        private ViewService() { }

        private EmployeeView employeeView;
        private ReportTemplateDesignerView reportTemplateDesignerView;
        private DutyView dutyView;

        public void ShowDialog(string viewModelName)
        {
            switch (viewModelName)
            {
                case nameof(EmployeeViewModel):
                    if (employeeView == null)
                        employeeView = new EmployeeView();
                    employeeView.Owner = App.Current.MainWindow;
                    employeeView.ShowDialog();
                    break;
                case nameof(ReportTemplateDesignerViewModel):
                    if (reportTemplateDesignerView == null)
                        reportTemplateDesignerView = new ReportTemplateDesignerView();
                    reportTemplateDesignerView.Owner = App.Current.MainWindow;
                    reportTemplateDesignerView.ShowDialog();
                    break;
                case nameof(DutyViewModel):
                    if (dutyView == null)
                        dutyView = new DutyView();
                    dutyView.Owner = App.Current.MainWindow;
                    dutyView.ShowDialog();
                    break;
            }
        }

        public void CloseDialog(string viewModelName)
        {
            switch (viewModelName)
            {
                case nameof(EmployeeViewModel):
                    employeeView.Close();
                    break;
                case nameof(ReportTemplateDesignerViewModel):
                    reportTemplateDesignerView.Close();
                    break;
                case nameof(DutyViewModel):
                    dutyView.Close();
                    break;
            }
        }
    }
}
