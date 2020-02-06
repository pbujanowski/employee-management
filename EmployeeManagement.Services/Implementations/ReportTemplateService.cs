using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class ReportTemplateService : IReportTemplateService<ReportTemplate>
    {
        public async Task<ReportTemplate> GetTemplateByCodeAsync(string reportCode)
        {
            return await HttpHelper.DoGetRequestAsync<ReportTemplate>(HttpUrls.ReportTemplatePath);
        }
    }
}