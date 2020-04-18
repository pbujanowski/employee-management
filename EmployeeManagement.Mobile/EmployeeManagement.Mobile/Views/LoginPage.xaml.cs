using EmployeeManagement.Mobile.Communication;
using EmployeeManagement.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManagement.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LoginViewModel();

            MessagingCenter.Subscribe<LoginViewModel>(this, Message.CloseLoginPage, async (obj) =>
            {
                await Navigation.PopModalAsync();
            });

            MessagingCenter.Subscribe<LoginViewModel, string>(this, Message.DisplayAlert, async (obj, args) =>
            {
                await DisplayAlert("Komunikat", args, "OK");
            });
        }
    }
}