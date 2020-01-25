using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Enums;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private string title;
        private Employee employee = new Employee();
        private readonly IViewService viewService = ViewService.Instance;
        private readonly IEmployeeService<Employee> employeeService = new EmployeeService();
        private readonly ICityService<City> cityService = new CityService();
        private readonly IJobService<Job> jobService = new JobService();
        private DataMode dataMode;

        public string Title 
        { 
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public string FirstName
        {
            get { return employee.FirstName; }
            set
            {
                employee.FirstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return employee.LastName; }
            set
            {
                employee.LastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }

        public Job Job
        {
            get { return employee.Job; }
            set
            {
                employee.Job = value;
                NotifyPropertyChanged(nameof(Job));
            }
        }

        public bool CanJob { get { return false; } }

        public ObservableCollection<Job> Jobs { get; private set; }

        public string Address
        {
            get { return employee.Address; }
            set
            {
                employee.Address = value;
                NotifyPropertyChanged(nameof(Address));
            }
        }

        public City City
        {
            get { return employee.City; }
            set
            {
                employee.City = value;
                NotifyPropertyChanged(nameof(City));
            }
        }

        public bool CanCity { get { return true; } }

        public ObservableCollection<City> Cities { get; private set; }

        public string PostalCode
        {
            get { return employee.PostalCode; }
            set
            {
                employee.PostalCode = value;
                NotifyPropertyChanged(nameof(PostalCode));
            }
        }

        public DateTime EmploymentDate
        {
            get { return employee.EmploymentDate; }
            set
            {
                employee.EmploymentDate = value;
                NotifyPropertyChanged(nameof(EmploymentDate));
            }
        }

        protected override string ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.IsNullOrWhiteSpace(FirstName))
                        return "Imię nie może być puste!";
                    else if (FirstName.Any(char.IsDigit))
                        return "Imię nie może zawierać cyfr!";
                    break;
                case nameof(LastName):
                    if (string.IsNullOrWhiteSpace(LastName))
                        return "Nazwisko nie może być puste!";
                    else if (LastName.Any(char.IsDigit))
                        return "Nazwisko nie może zawierać cyfr!";
                    break;
            }
            return null;
        }

        public ICommand AcceptEmployeeCommand { get; private set; }

        public ICommand CancelEmployeeCommand { get; private set; }

        public ICommand GetCitiesCommand { get; private set; }

        public ICommand GetJobsCommand { get; private set; }

        private async void AcceptEmployee(object parameter)
        {
            switch (dataMode)
            {
                case DataMode.Add:
                    await employeeService.AddOneAsync(employee);
                    break;
                case DataMode.Edit:
                    await employeeService.UpdateOneAsync(employee);
                    break;
            }
        }

        private void CancelEmployee(object parameter)
        {
            viewService.CloseDialog(nameof(EmployeeViewModel));
        }

        private async void GetCities(object parameter)
        {
            var cities = await cityService.GetAllAsync();
            if (this.Cities == null)
                this.Cities = new ObservableCollection<City>();
            else
                this.Cities.Clear();

            foreach (var city in cities)
                this.Cities.Add(city);
        }

        private async void GetJobs(object parameter)
        {
            var jobs = await jobService.GetAllAsync();
            if (this.Jobs == null)
                this.Jobs = new ObservableCollection<Job>();
            else
                this.Jobs.Clear();

            foreach (var job in jobs)
                this.Jobs.Add(job);
        }

        private void SetAddMode()
        {
            Title = "Dodaj pracownika";
            dataMode = DataMode.Add;
        }

        private void SetEditMode(Employee employee)
        {
            Title = "Edytuj pracownika";
            dataMode = DataMode.Edit;
            this.employee = employee;
        }

        //public override async void OnDialogOpened(IDialogParameters parameters)
        //{
        //    Jobs = await employeeService.GetAllJobsAsync();
        //    switch (parameters.GetValue<DataMode>("DataMode"))
        //    {
        //        case DataMode.Add:
        //            SetAddMode();
        //            break;
        //        case DataMode.Edit:
        //            SetEditMode(parameters.GetValue<Employee>("Employee"));
        //            break;
        //        default:
        //            throw new ArgumentException("Przekazano nieprawidłowy parametr trybu danych!");
        //    }
        //}

        //public override void OnDialogClosed()
        //{
        //    base.OnDialogClosed();
        //}

        public EmployeeViewModel()
        {
            AcceptEmployeeCommand = new RelayCommand<object>(AcceptEmployee);
            CancelEmployeeCommand = new RelayCommand<object>(CancelEmployee);
            GetCitiesCommand = new RelayCommand<object>(GetCities);
            GetJobsCommand = new RelayCommand<object>(GetJobs);
            SetAddMode();
        }
    }
}
