using EmployeeManagement.Core.Models;
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

        public DutiesViewModel()
        {
            Title = "Zadania";
            Duties = new ObservableCollection<Duty>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Duty>(this, "AddItem", async (obj, duty) =>
            //{
            //    var newDuty = duty as Duty;
            //    Duties.Add(newDuty);
            //    await DataStore.AddItemAsync(newDuty);
            //});
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Duties.Clear();
                var duties = await dutyService.GetAllByEmployeeIdAsync(Session.User.Employee.Id);
                foreach (var duty in duties)
                {
                    Duties.Add(duty);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(this, "DisplayAlert", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}