using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.ViewModels;
using EmployeeManagement.Desktop.Views;

namespace EmployeeManagement.Desktop.Services
{
    public class ViewService : IViewService
    {
        private static readonly object locker = new object();
        private static ViewService instance;
        public static ViewService Instance { get { lock (locker) { return instance ?? (instance = new ViewService()); } } }

        private ViewService()
        {
        }

        private EmployeeView employeeView;
        private ReportTemplateDesignerView reportTemplateDesignerView;
        private DutyView dutyView;
        private LoginView loginView;

        public void ShowDialog(string viewModelName)
        {
            switch (viewModelName)
            {
                case nameof(EmployeeViewModel):
                    employeeView = new EmployeeView();
                    employeeView.Owner = App.Current.MainWindow;
                    employeeView.ShowDialog();
                    break;

                case nameof(ReportTemplateDesignerViewModel):
                    reportTemplateDesignerView = new ReportTemplateDesignerView();
                    reportTemplateDesignerView.Owner = App.Current.MainWindow;
                    reportTemplateDesignerView.ShowDialog();
                    break;

                case nameof(DutyViewModel):
                    dutyView = new DutyView();
                    dutyView.Owner = App.Current.MainWindow;
                    dutyView.ShowDialog();
                    break;

                case nameof(LoginViewModel):
                    loginView = new LoginView();
                    loginView.Owner = App.Current.MainWindow;
                    loginView.ShowDialog();
                    break;
            }
        }

        public void ShowDialog(string viewModelName, object parameter)
        {
            switch (viewModelName)
            {
                case nameof(EmployeeViewModel):
                    employeeView = new EmployeeView();
                    employeeView.Owner = App.Current.MainWindow;
                    employeeView.DataContext = new EmployeeViewModel((Employee)parameter);
                    employeeView.ShowDialog();
                    break;

                case nameof(DutyViewModel):
                    dutyView = new DutyView();
                    dutyView.Owner = App.Current.MainWindow;
                    dutyView.DataContext = new DutyViewModel((Duty)parameter);
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

                case nameof(LoginViewModel):
                    loginView.Close();
                    break;
            }
        }
    }
}