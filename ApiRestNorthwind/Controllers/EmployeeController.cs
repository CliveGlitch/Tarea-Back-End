using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind_Database.Services;
using Northwind_Database.DataAccess;
using Northwind_Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwind.Controllers
{
    [EnableCors("foo")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeSC employeeService = new EmployeeSC();

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            var employees = new EmployeeSC().GetAllEmployees().ToList();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var employee = employeeService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel newEmployee)
        {
            try
            {
                employeeService.AddEmployee(newEmployee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            try
            {
                employeeService.UpdateEmployeeFirstNameById(id, name);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                employeeService.DeleteEmployeeById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
