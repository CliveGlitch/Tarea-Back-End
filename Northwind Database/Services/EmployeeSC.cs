using Northwind_Database.DataAccess;
using Northwind_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Database.Services
{

    public class EmployeeSC : BaseSC
    {
        // GET BY ID
        public Employee GetEmployeeById(int id)
        {
            var employee = GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();

            if (employee == null)
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");

            return employee;
        }

        // GET ALL
        public IQueryable<Employee> GetAllEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }

        // DELETE
        public void DeleteEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        // PUT
        public void UpdateEmployeeFirstNameById(int id, string newName)
        {
            Employee currentEmployee = GetEmployeeById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentEmployee.FirstName = newName;
            dataContext.SaveChanges();
        }

        // POST
        public void AddEmployee(EmployeeModel newEmployee)
        {
            // notación parecida a JSON
            var newEmployeeRegister = new Employee()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.SurName
            };

            dataContext.Employees.Add(newEmployeeRegister);
            dataContext.SaveChanges();
        }
    }
}
