using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Desktop.Constants
{
    public static class HttpUrls
    {
        private const string BaseUrl = "https://localhost:44305/api";

        public const string DutyPath = BaseUrl + "/duties/";
        
        public const string EmployeePath = BaseUrl + "/employees/";
    }
}
