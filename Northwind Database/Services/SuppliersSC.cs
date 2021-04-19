using Northwind_Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Database.Services
{
    class SuppliersSC : BaseSC 
    {
        public IQueryable<Supplier> GetAllSuppliers()
        {
            return dataContext.Suppliers.Select(s => s);
        }
    }
}
