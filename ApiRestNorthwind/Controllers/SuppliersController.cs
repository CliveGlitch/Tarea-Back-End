using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind_Database.DataAccess;
using Northwind_Database.Models;
using Northwind_Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwind.Controllers
{
    [EnableCors("foo")]
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        new SuppliersSC supplierService = new SuppliersSC();

        // GET: api/<SuppliersController>
        [HttpGet]
        public List<Supplier> Get()
        {
            var supplier = new SuppliersSC().GetAllSuppliers().ToList();
            return supplier;
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = supplierService.GetSupplierById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierModel newSupplier)
        {
            try
            {
                supplierService.AddSupplier(newSupplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string company)
        {
            try
            {
                supplierService.UpdateSupplierCompanyNameById(id, company);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                supplierService.DeleteSupplierById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
