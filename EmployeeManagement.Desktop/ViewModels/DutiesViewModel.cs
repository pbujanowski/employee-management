using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class DutiesViewModel : BindableBase
    {
        private readonly IDutyService<Duty> dutyService;
        private ObservableCollection<Duty> duties;
        private Duty selectedDuty;

        private async Task GetDuties()
        {
            try
            {
                if (Duties == null)
                    Duties = new ObservableCollection<Duty>();

                var duties = await dutyService.GetAllAsync().ConfigureAwait(false);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Duties.Clear();

                    foreach (var duty in duties)
                        Duties.Add(duty);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<Duty> Duties
        {
            get { return duties; }
            set { SetProperty(ref duties, value); }
        }

        public Duty SelectedDuty
        {
            get { return selectedDuty; }
            set { SetProperty(ref selectedDuty, value); }
        }

        public ICommand RefreshDutiesListCommand { get; }

        private async void ExecuteRefreshDutiesList()
        {
            await GetDuties().ConfigureAwait(false);
        }

        public DutiesViewModel(IDutyService<Duty> dutyService)
        {
            this.dutyService = dutyService;
            RefreshDutiesListCommand = new DelegateCommand(ExecuteRefreshDutiesList);
        }
    }
}
