using EmployeeManagement.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManagement.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DutiesPage : ContentPage
    {
        private DutiesViewModel viewModel;

        public DutiesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new DutiesViewModel();
        }
    }
}