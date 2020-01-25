using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
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
    public class DutiesViewModel : ViewModelBase
    {
        private readonly IDutyService<Duty> dutyService = new DutyService();
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
            set 
            {
                duties = value;
                NotifyPropertyChanged(nameof(Duties));
            }
        }

        public Duty SelectedDuty
        {
            get { return selectedDuty; }
            set 
            {
                selectedDuty = value;
                NotifyPropertyChanged(nameof(SelectedDuty));
            }
        }

        public ICommand AddDutyCommand { get; }

        public ICommand RefreshDutiesListCommand { get; }

        private void AddDuty(object parameter)
        {

        }

        private async void RefreshDutiesList(object parameter)
        {
            await GetDuties().ConfigureAwait(false);
        }

        public DutiesViewModel()
        {
            AddDutyCommand = new RelayCommand<object>(AddDuty);
            RefreshDutiesListCommand = new RelayCommand<object>(RefreshDutiesList);
        }
    }
}
