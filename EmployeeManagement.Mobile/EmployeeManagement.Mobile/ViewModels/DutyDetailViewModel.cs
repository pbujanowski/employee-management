using EmployeeManagement.Core.Models;

namespace EmployeeManagement.Mobile.ViewModels
{
    public class DutyDetailViewModel : BaseViewModel
    {
        public Duty Duty { get; set; }

        public DutyDetailViewModel(Duty duty = null)
        {
            Title = duty?.Description;
            Duty = duty;
        }
    }
}