using EmployeeManagement.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services
{
    public abstract class ServiceBase
    {
        protected ApplicationDbContext context;

        protected ServiceBase(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
