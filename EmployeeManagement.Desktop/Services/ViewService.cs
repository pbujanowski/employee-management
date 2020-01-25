using EmployeeManagement.Desktop.ViewModels;
using EmployeeManagement.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Desktop.Services
{
    public class ViewService : IViewService
    {
        public void ShowDialog(string viewModelName)
        {
            switch (viewModelName)
            {
                case nameof(EmployeeViewModel):
                    var employeeView = new EmployeeView();
                    employeeView.ShowDialog();
                    break;
                case nameof(ReportTemplateDesignerViewModel):
                    var reportTemplateDesignerView = new ReportTemplateDesignerView();
                    reportTemplateDesignerView.ShowDialog();
                    break;
            }
        }
    }
}
