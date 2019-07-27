using EmployeeManagement.Desktop.Constants;
using Prism.Mvvm;
using Prism.Regions;

namespace EmployeeManagement.Desktop.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private string _title = "Zarządzanie kadrą pracowniczą";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private void RegisterViewsWithRegions()
        {
            regionManager.RegisterViewWithRegion(Regions.TopPanelRegion, typeof(Views.TopPanelView));
            regionManager.RegisterViewWithRegion(Regions.MainRegion, typeof(Views.MainView));
            regionManager.RegisterViewWithRegion(Regions.EmployeesRegion, typeof(Views.EmployeesView));
            regionManager.RegisterViewWithRegion(Regions.DutiesRegion, typeof(Views.DutiesView));
            regionManager.RegisterViewWithRegion(Regions.ScheduleRegion, typeof(Views.ScheduleView));
        }

        public ShellViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            RegisterViewsWithRegions();
        }
    }
}
