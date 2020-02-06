using EmployeeManagement.Core.Models;
using EmployeeManagement.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DutiesPage : ContentPage
    {
        private DutiesViewModel viewModel;

        public DutiesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DutiesViewModel();
            MessagingCenter.Subscribe<DutiesViewModel, string>(this, "DisplayAlert", async (obj, message) =>
            {
                await DisplayAlert("Komunikat", message, "OK");
            });
        }

        private async void OnDutySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var duty = args.SelectedItem as Duty;
            if (duty == null)
                return;
            await Navigation.PushAsync(new DutyDetailPage(new DutyDetailViewModel(duty)));

            // Manually deselect item.
            DutiesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Duties.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}