using Northwind_Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Database.Services
{
    class EmployeeSC : BaseSC
    {
        public IQueryable<Employee> GetAllEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }
    }
}
