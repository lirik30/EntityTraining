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

        public ProductService(DbContext context) => _context = context;

        public Product GetProductEntity(string title)
        {
            return _context.Set<Product>().FirstOrDefault(x => x.Title == title);
        }

        public IEnumerable<Product> GetAll()
        {
            var all = _context.Set<Product>();
            return all;
        }

        public void Create(Product product)
        {
            if (_context.Set<Product>().FirstOrDefault(x => x.Title == product.Title) != null)
                throw new InvalidOperationException($"Product {product.Title} exist in this storage");

            _context.Set<Product>().Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            var deletedProd = _context.Set<Product>().SingleOrDefault(x => x.Title == product.Title);
            if(deletedProd == null)
                throw new InvalidOperationException($"Product {product.Title} doesn't exist");

            _context.Set<Product>().Remove(deletedProd);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            //?
            throw new NotImplementedException();
        }
    }
}
