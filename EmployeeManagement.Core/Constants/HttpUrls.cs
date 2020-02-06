namespace EmployeeManagement.Core.Constants
{
    public static class HttpUrls
    {
        private const string BaseUrl = "https://192.168.43.128:5001/api";

        public static readonly string DutyPath = BaseUrl + "/duties/";

        public static readonly string EmployeePath = BaseUrl + "/employees/";

        public static readonly string JobPath = BaseUrl + "/jobs/";

        public static readonly string CityPath = BaseUrl + "/cities/";

        public static readonly string UsersLoginPath = BaseUrl + "/users/login/";

        public static readonly string UsersRegisterPath = BaseUrl + "/users/register/";

        public static readonly string ReportTemplatePath = BaseUrl + "/reporttemplates/gettemplatebycode/";
    }
}