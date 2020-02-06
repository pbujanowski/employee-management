using EmployeeManagement.API.Data;

namespace EmployeeManagement.API.Services
{
    public abstract class ServiceBase
    {
        protected ApplicationDbContext dbContext;

        protected ServiceBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}