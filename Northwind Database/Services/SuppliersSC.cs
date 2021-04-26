using Northwind_Database.DataAccess;
using Northwind_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Database.Services
{
    public class SuppliersSC : BaseSC 
    {
        // GET ALL
        public IQueryable<Supplier> GetAllSuppliers()
        {
            return dataContext.Suppliers.Select(s => s);
        }

        // GET BY ID
        public Supplier GetSupplierById(int id)
        {
            var supplier = GetAllSuppliers().Where(w => w.SupplierId == id).FirstOrDefault();

            if (supplier == null)
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");

            return supplier;
        }

        // DELETE
        public void DeleteSupplierById(int id)
        {
            var supplier = GetSupplierById(id);
            dataContext.Suppliers.Remove(supplier);
            dataContext.SaveChanges();
        }

        // PUT
        public void UpdateSupplierCompanyNameById(int id, string newName)
        {
            Supplier currentSupplier = GetSupplierById(id);

            if (currentSupplier == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentSupplier.CompanyName = newName;
            dataContext.SaveChanges();
        }

        // POST
        public void AddSupplier(SupplierModel newSupplier)
        {
            // notación parecida a JSON
            var newSupplierRegister = new Supplier()
            {
                CompanyName = newSupplier.Company,
                ContactName = newSupplier.NameContact,
                ContactTitle = newSupplier.TitleContact
            };

            dataContext.Suppliers.Add(newSupplierRegister);
            dataContext.SaveChanges();
        }
    }
}
