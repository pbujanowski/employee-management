using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EmployeeManagement.Mobile.Services;
using EmployeeManagement.Mobile.Views;
using EmployeeManagement.Services.Implementations;

namespace EmployeeManagement.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DutyService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
