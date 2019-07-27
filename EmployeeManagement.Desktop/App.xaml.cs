using Prism.Ioc;
using EmployeeManagement.Desktop.Views;
using System.Windows;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Desktop.ViewModels;

namespace EmployeeManagement.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IEmployeeService<Employee>, EmployeeService>();
            containerRegistry.Register<IDutyService<Duty>, DutyService>();
            containerRegistry.RegisterDialog<EmployeeView, EmployeeViewModel>();
        }
    }
}
