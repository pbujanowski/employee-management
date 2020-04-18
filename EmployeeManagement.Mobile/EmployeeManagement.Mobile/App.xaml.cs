using EmployeeManagement.Services.Implementations;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<DutyService>();
            DependencyService.Register<UserService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}