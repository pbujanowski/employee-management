using EmployeeManagement.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DutyDetailPage : ContentPage
    {
        private DutyDetailViewModel viewModel;

        public DutyDetailPage(DutyDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DutyDetailPage()
        {
            InitializeComponent();

            viewModel = new DutyDetailViewModel(null);
            BindingContext = viewModel;
        }
    }
}