using Northwind_Database.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Database.Services
{
    class ProductsSC : BaseSC
    {
        public IQueryable<Product> GetAllProducts()
        {
            return dataContext.Products.Select(s => s);
        }
    }
}
