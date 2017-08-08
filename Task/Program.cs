using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var purchase1 = new Purchase { PurchaseId = 1, Basket = new List<Order> { order4, order2 } };
                var purchase2 = new Purchase { PurchaseId = 2, Basket = new List<Order> { order3, order1 } };

                db.Products.Add(phone);
                db.Products.Add(auto);
                db.Products.Add(window);
                db.Products.Add(ball);
                db.SaveChanges();
                db.Purchases.Add(purchase1);
                db.Purchases.Add(purchase2);
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
            DbContext context = new ShopContext();
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

            var order1 = new Order { OrderId = 1, Product = phone, Quantity = 1 };
            var order2 = new Order { OrderId = 2, Product = ball, Quantity = 2 };
            var order3 = new Order { OrderId = 3, Product = auto, Quantity = 5 };
            var order4 = new Order { OrderId = 4, Product = window, Quantity = 10 };
            var purchase1 = new Purchase {PurchaseId = 1, Basket = new List<Order> {order4, order2}};
            var purchase2 = new Purchase {PurchaseId = 2, Basket = new List<Order> {order3, order1}};

            var service1 = new ProductService(context);
            var service2 = new PurchaseService(context);
            service1.CreateProduct(phone);
            //service.Create(phone); throws exception
            service1.CreateProduct(auto);
            service1.CreateProduct(window);
            service1.CreateProduct(ball);
            Console.WriteLine("___Products___");
            foreach (var item in service1.GetAllProducts())
            {
                Console.WriteLine(item);
            }

            service2.CreatePurchase(purchase1);
            service2.CreatePurchase(purchase2);
            Console.WriteLine("__Purchases___");
            foreach (var item in service2.GetAllPurchases())
            {
                Console.WriteLine(item);
            }

            service2.DeletePurchase(purchase1);
            Console.WriteLine("__Purchases_after_deleting___");
            foreach (var item in service2.GetAllPurchases())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("__Products_after_deleting___");
            foreach (var item in service1.GetAllProducts())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("__Orders___");
            foreach (var item in context.Set<Order>())
            {
                Console.WriteLine(item.OrderId);
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //TestWithoutService();
            TestWithService();
        }
    }
}
