using Northwind_Database.DataAccess;
using Northwind_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_Database.Services
{
    public class ProductsSC : BaseSC
    {
        // GET ALL
        public IQueryable<Product> GetAllProducts()
        {
            return dataContext.Products.Select(s => s);
        }

        // GET BY ID
        public Product GetProductById(int id)
        {
            var product = GetAllProducts().Where(w => w.ProductId == id).FirstOrDefault();

            if (product == null)
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");

            return product;
        }

        // DELETE
        public void DeleteProductById(int id)
        {
            var product = GetProductById(id);
            dataContext.Products.Remove(product);
            dataContext.SaveChanges();
        }

        // PUT
        public void UpdateProductNameById(int id, string newName)
        {
            Product currentProduct = GetProductById(id);

            if (currentProduct == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentProduct.ProductName = newName;
            dataContext.SaveChanges();
        }

        // POST
        public void AddProduct(ProductModel newProduct)
        {
            // notación parecida a JSON
            var newProductRegister = new Product()
            {
                ProductName = newProduct.Name
            };

            dataContext.Products.Add(newProductRegister);
            dataContext.SaveChanges();
        }
    }
}
