using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities;

namespace Task.Services
{
    public class ProductService
    {
        private DbContext _context;

        /// <summary>
        /// Create service for work with products
        /// </summary>
        /// <param name="context"></param>
        public ProductService(DbContext context) => _context = context;

        /// <summary>
        /// Get product by title
        /// </summary>
        /// <param name="title">Title of product</param>
        /// <returns>Product if it exists, otherwise null</returns>
        public Product GetProductEntity(string title)
        {
            return _context.Set<Product>().FirstOrDefault(x => x.Title == title);
        }

        /// <summary>
        /// Get all orders from DB?
        /// </summary>
        /// <returns>Collection of products from database</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            var all = _context.Set<Product>();
            return all;
        }

        /// <summary>
        /// Create order in the DB
        /// </summary>
        /// <param name="product">Product to adding</param>
        public void CreateProduct(Product product)
        {
            if (_context.Set<Product>().FirstOrDefault(x => x.Title == product.Title) != null)
                throw new InvalidOperationException($"Product {product.Title} exist in this storage");

            _context.Set<Product>().Add(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete order from DB
        /// </summary>
        /// <param name="product">Product to delete</param>
        public void DeleteProduct(Product product)
        {
            var deletedProd = _context.Set<Product>().SingleOrDefault(x => x.Title == product.Title);
            if(deletedProd == null)
                throw new InvalidOperationException($"Product {product.Title} doesn't exist");

            _context.Set<Product>().Remove(deletedProd);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
