using EmployeeManagement.Core.Models;
using EmployeeManagement.Mobile.Services;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class DutyDetailViewModel : BaseViewModel
    {
        private readonly IDutyService<Duty> dutyService = DependencyService.Get<IDutyService<Duty>>();

        public string Info { get; set; }

        public Duty Duty { get; set; }

        public Command BeginDutyCommand { get; }

        public Command EndDutyCommand { get; }

        public bool CanBeginDutyCommand { get { return Duty.BeginDate == null; } }

        public bool CanEndDutyCommand { get { return Duty.BeginDate != null; } }

        private async Task ExecuteBeginDutyCommand()
        {
            try
            {
                Info = "Proszę czekać...";

                Duty.BeginDate = DateTime.Now;
                await dutyService.UpdateOneAsync(Duty);

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageService.DisplayAlert(this, ex.Message);
            }
            finally
            {
                BeginDutyCommand.ChangeCanExecute();
                EndDutyCommand.ChangeCanExecute();
            }
        }

        private async Task ExecuteEndDutyCommand()
        {
            try
            {
                Info = "Proszę czekać...";

                Duty.EndDate = DateTime.Now;
                await dutyService.UpdateOneAsync(Duty);

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageService.DisplayAlert(this, ex.Message);
            }
            finally
            {
                BeginDutyCommand.ChangeCanExecute();
                EndDutyCommand.ChangeCanExecute();
            }
        }

        public DutyDetailViewModel(Duty duty = null)
        {
            Title = duty?.Description;
            Duty = duty;
            BeginDutyCommand = new Command(async () => await ExecuteBeginDutyCommand(), () => CanBeginDutyCommand);
            EndDutyCommand = new Command(async () => await ExecuteEndDutyCommand(), () => CanEndDutyCommand);
        }
    }
}