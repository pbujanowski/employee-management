using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Constants
{
    public static class HttpUrls
    {
        private const string BaseUrl = "https://192.168.8.110:44305/api";

        public const string DutyPath = BaseUrl + "/duties/";
        
        public const string EmployeePath = BaseUrl + "/employees/";

        public const string JobPath = BaseUrl + "/jobs/";

        public const string CityPath = BaseUrl + "/cities/";

        public const string UsersLoginPath = BaseUrl + "/users/login/";

        public const string UsersRegisterPath = BaseUrl + "/users/register/";

        public const string ReportTemplatePath = BaseUrl + "/reporttemplates/gettemplatebycode/";
    }
}
