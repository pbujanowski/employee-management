using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Desktop.Services
{
    public interface IViewService
    {
        void ShowDialog(string viewModelName);

        void CloseDialog(string viewModelName);
    }
}
