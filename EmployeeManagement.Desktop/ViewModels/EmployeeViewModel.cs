using EmployeeManagement.Core.Models;
using EmployeeManagement.Desktop.Enums;
using EmployeeManagement.Desktop.Services;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private string info;
        private Employee employee = new Employee();
        private ObservableCollection<City> cities;
        private readonly IEmployeeService<Employee> employeeService = new EmployeeService();
        private readonly ICityService<City> cityService = new CityService();
        private readonly IJobService<Job> jobService = new JobService();
        private DataMode dataMode;

        public string Info 
        {
            get { return info; }
            set
            {
                info = value;
                NotifyPropertyChanged(nameof(Info));
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
                employee.CityId = value.Id;
                NotifyPropertyChanged(nameof(City));
            }
        }

        public bool CanCity { get { return true; } }

        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                NotifyPropertyChanged(nameof(Cities));
            }
        }

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

                case nameof(Address):
                    if (string.IsNullOrWhiteSpace(Address))
                        return "Adres zamieszkania nie może być pusty!";
                    break;

                case nameof(City):
                    if (string.IsNullOrWhiteSpace(City?.Name))
                        return "Należy wybrać miasto zamieszkania!";
                    break;

                case nameof(EmploymentDate):
                    if (EmploymentDate.Date > DateTime.Now.Date)
                        return "Data zatrudnienia nie może dotyczyć przyszłości!";
                    break;
            }
            return null;
        }

        public ICommand AcceptEmployeeCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public ICommand GetCitiesCommand { get; private set; }

        public ICommand GetJobsCommand { get; private set; }

        private async void AcceptEmployee(object parameter)
        {
            try
            {
                Info = "Proszę czekać...";

                switch (dataMode)
                {
                    case DataMode.Add:
                        await employeeService.AddOneAsync(employee);
                        CloseCommand.Execute(null);
                        break;

                    case DataMode.Edit:
                        await employeeService.UpdateOneAsync(employee);
                        CloseCommand.Execute(null);
                        break;
                }

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageService.ShowError(ex.Message);
            }
        }

        private void Close(object parameter)
        {
            viewService.CloseDialog(nameof(EmployeeViewModel));
        }

        private async void GetCities(object parameter)
        {
            try
            {
                Info = "Proszę czekać...";

                var cities = await cityService.GetAllAsync();
                if (this.Cities == null)
                    this.Cities = new ObservableCollection<City>();
                else
                    this.Cities.Clear();

                foreach (var city in cities)
                    this.Cities.Add(city);

                City = Cities.First();

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageService.ShowError(ex.Message);
            }
        }

        private async void GetJobs(object parameter)
        {
            try
            {
                Info = "Proszę czekać...";

                var jobs = await jobService.GetAllAsync();
                if (this.Jobs == null)
                    this.Jobs = new ObservableCollection<Job>();
                else
                    this.Jobs.Clear();

                foreach (var job in jobs)
                    this.Jobs.Add(job);

                Info = "Gotowe!";
            }
            catch (Exception ex)
            {
                Info = "Błąd!";
                MessageBox.Show(ex.Message);
            }
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

        private void Initialize()
        {
            AcceptEmployeeCommand = new RelayCommand<object>(AcceptEmployee);
            CloseCommand = new RelayCommand<object>(Close);
            GetCitiesCommand = new RelayCommand<object>(GetCities);
            GetJobsCommand = new RelayCommand<object>(GetJobs);
        }

        public EmployeeViewModel()
        {
            Initialize();
            SetAddMode();
        }

        public EmployeeViewModel(Employee employee)
        {
            Initialize();
            SetEditMode(employee);
        }
    }
}