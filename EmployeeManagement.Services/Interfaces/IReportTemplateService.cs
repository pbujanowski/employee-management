using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IReportTemplateService<T>
    {
        Task<T> GetTemplateByCodeAsync(string reportCode);
    }
}
