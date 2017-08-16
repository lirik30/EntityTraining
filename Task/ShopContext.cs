using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities;

namespace Task
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("name=ShopContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
