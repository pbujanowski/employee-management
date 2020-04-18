using EmployeeManagement.Core.Models;
using EmployeeManagement.Mobile.Communication;
using EmployeeManagement.Mobile.Services;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class DutiesViewModel : BaseViewModel
    {
        private readonly IDutyService<Duty> dutyService = DependencyService.Get<IDutyService<Duty>>();
        public ObservableCollection<Duty> Duties { get; set; }
        public Command LoadItemsCommand { get; set; }

        public bool CanExecuteLoadItemsCommand { get { return Session.User != null; } }

        public DutiesViewModel()
        {
            Title = "Zadania";
            Duties = new ObservableCollection<Duty>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(), () => CanExecuteLoadItemsCommand);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Duties.Clear();
                //var duties = await dutyService.GetAllByEmployeeIdAsync(Session.User.Employee.Id);
                var duties = await dutyService.GetAllAsync();
                foreach (var duty in duties)
                {
                    Duties.Add(duty);
                }
            }
            catch (Exception ex)
            {
                MessageService.DisplayAlert(this, ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}