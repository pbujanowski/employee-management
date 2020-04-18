namespace EmployeeManagement.Core.Constants
{
    public static class HttpUrls
    {
        private const string BaseUrl = "https://192.168.8.110:5001/api";

        public static readonly string DutyPath = BaseUrl + "/duties/";

        public static readonly string EmployeePath = BaseUrl + "/employees/";

        public static readonly string JobPath = BaseUrl + "/jobs/";

        public static readonly string CityPath = BaseUrl + "/cities/";

        public static readonly string UsersPath = BaseUrl + "/users/login/";

        public static readonly string AuthenticationPath = BaseUrl + "/authentication/";

        public static readonly string AuthenticationAuthenticate = AuthenticationPath + "authenticate/";

        public static readonly string ReportTemplatePath = BaseUrl + "/reporttemplates/gettemplatebycode/";
    }
}