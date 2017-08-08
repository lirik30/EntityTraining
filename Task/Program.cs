using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities;
using Task.Services;

namespace Task
{
    class Program
    {

        static void TestWithoutService()
        {
            using (var db = new ShopContext())
            {
                Console.WriteLine("Start work with DB: ");
                var phone = new Product
                {
                    Category = Category.Electronics,
                    Description = "New mobile phone",
                    Image = null,
                    Price = 350,
                    Title = "iPhone blabla"
                };

                var auto = new Product
                {
                    Category = Category.AutoMoto,
                    Description = "New auto",
                    Image = null,
                    Price = 5000,
                    Title = "Audi"
                };

                var window = new Product
                {
                    Category = Category.BuildingAndRepair,
                    Description = "New euro window",
                    Image = null,
                    Price = 100,
                    Title = "EuroWindowSuperCool"
                };

                var ball = new Product
                {
                    Category = Category.Sport,
                    Description = "New football ball",
                    Image = null,
                    Price = 15,
                    Title = "Nike ball"
                };

                var order1 = new Order { Product = phone, Quantity = 1 };
                var order2 = new Order { Product = ball, Quantity = 2 };
                var order3 = new Order { Product = auto, Quantity = 3 };
                var order4 = new Order { Product = window, Quantity = 10 };
                var purchase = new Purchase { Basket = new List<Order> { order1, order2, order3, order4 }, PurchaseId = 1 };

                db.Products.Add(phone);
                db.Products.Add(auto);
                db.Products.Add(window);
                db.Products.Add(ball);
                db.Purchases.Add(purchase);
                db.SaveChanges();

                var prodQuery = from p in db.Products
                                orderby p.Title
                                select p;

                var purchaseQ = from p in db.Purchases
                                select p;

                Console.WriteLine("---PRODUCTS---");
                foreach (var item in prodQuery)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                Console.WriteLine("---PURCHASE---");
                foreach (var item in purchaseQ)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
            }
        }

        static void TestWithService()
        {
            Console.WriteLine("Start work with DB: ");
            var phone = new Product
            {
                Category = Category.Electronics,
                Description = "New mobile phone",
                Image = null,
                Price = 350,
                Title = "iPhone blabla"
            };

            var auto = new Product
            {
                Category = Category.AutoMoto,
                Description = "New auto",
                Image = null,
                Price = 5000,
                Title = "Audi"
            };

            var window = new Product
            {
                Category = Category.BuildingAndRepair,
                Description = "New euro window",
                Image = null,
                Price = 100,
                Title = "EuroWindowSuperCool"
            };

            var ball = new Product
            {
                Category = Category.Sport,
                Description = "New football ball",
                Image = null,
                Price = 15,
                Title = "Nike ball"
            };

            var service = new ProductService(new ShopContext());
            service.Create(phone);
            //service.Create(phone); throws exception
            service.Create(auto);
            service.Create(window);
            service.Create(ball);

            foreach (var item in service.GetAll())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //TestWithoutService();
            //TestWithService();
        }
    }
}
