using EmployeeManagement.Mobile.Communication;
using EmployeeManagement.Mobile.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;

namespace EmployeeManagement.Mobile.Views
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainViewModel();

            MessagingCenter.Subscribe<MainViewModel>(this, Message.OpenLoginPage, async (obj) =>
            {
                await Navigation.PushModalAsync(new LoginPage());
            });
        }
    }
}