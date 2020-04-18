using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
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
        private string info;

        public string Info 
        {
            get { return info; }
            set
            {
                info = value;
                NotifyPropertyChanged(nameof(Info));
            }
        }

        private async Task GetDuties()
        {
            try
            {
                Info = "Proszę czekać...";

                if (Duties == null)
                    Duties = new ObservableCollection<Duty>();

                var duties = await dutyService.GetAllAsync().ConfigureAwait(false);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Duties.Clear();

                    foreach (var duty in duties)
                        Duties.Add(duty);
                });

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
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

        public ICommand EditDutyCommand { get; }

        public ICommand RefreshDutiesListCommand { get; }

        public bool CanEditDuty { get { return SelectedDuty != null; } }

        private void AddDuty(object parameter)
        {
            viewService.ShowDialog(nameof(DutyViewModel));
        }

        private void EditDuty(object parameter)
        {
            viewService.ShowDialog(nameof(DutyViewModel), SelectedDuty);
        }

        private async void RefreshDutiesList(object parameter)
        {
            await GetDuties().ConfigureAwait(false);
        }

        public DutiesViewModel()
        {
            AddDutyCommand = new RelayCommand<object>(AddDuty);
            EditDutyCommand = new RelayCommand<object>(EditDuty, (obj) => CanEditDuty);
            RefreshDutiesListCommand = new RelayCommand<object>(RefreshDutiesList);
        }
    }
}