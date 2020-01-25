using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class DutiesViewModel : BaseViewModel
    {
        private readonly IDutyService<Duty> dutyService = DependencyService.Get<IDutyService<Duty>>();
        private string error;

        public ObservableCollection<Duty> Duties { get; set; }
        public Command LoadDutiesCommand { get; set; }

        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        public DutiesViewModel()
        {
            Title = "Zadania";
            Duties = new ObservableCollection<Duty>();
            LoadDutiesCommand = new Command(async () => await LoadDuties());
        }

        private async Task LoadDuties()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Duties.Clear();
                var duties = await dutyService.GetAllAsync().ConfigureAwait(false);
                foreach (var duty in duties)
                    Duties.Add(duty);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Error = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
