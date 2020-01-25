using EmployeeManagement.Desktop.Views;
using System.Windows;
using EmployeeManagement.Services;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.ViewModels;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services.Implementations;

namespace EmployeeManagement.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static User CurrentUser { get; set; }
    }
}
