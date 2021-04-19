using Northwind_Database.DataAccess;
using System;
using System.Linq;

namespace Northwind_Database
{
    class Program
    {
        public static void SelectSimple()
        {
            // select *from Employees
            NORTHWNDContext dataContext = new NORTHWNDContext();

            var employeeQry = dataContext.Employees.Select(s => s).AsQueryable();
            var output = employeeQry.ToList();
        }

        static void Main(string[] args)
        {
            SelectSimple();
        }
    }
}
