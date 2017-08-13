using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities;

namespace Task.Services
{
    class PurchaseService
    {
        private DbContext _context;

        /// <summary>
        /// Create service for work with purchases
        /// </summary>
        /// <param name="context"></param>
        public PurchaseService(DbContext context) => _context = context;

        /// <summary>
        /// Get purchase by id
        /// </summary>
        /// <param name="id">Id of purchase</param>
        /// <returns>Purchase if it exists, otherwise null</returns>
        public Purchase GetPurchaseEntity(int id)
        {
            return _context.Set<Purchase>().FirstOrDefault(x => x.PurchaseId == id);
        }

        /// <summary>
        /// Get all orders from DB?
        /// </summary>
        /// <returns>Collection of purchases from database</returns>
        public IEnumerable<Purchase> GetAllPurchases()
        {
            var all = _context.Set<Purchase>();
            return all;
        }

        /// <summary>
        /// Create order in the DB
        /// </summary>
        /// <param name="purchase">Purchase to adding</param>
        public void CreatePurchase(Purchase purchase)
        {
            if (_context.Set<Purchase>().FirstOrDefault(x => x.PurchaseId == purchase.PurchaseId) != null)
                throw new InvalidOperationException($"Purchase №{purchase.PurchaseId} exist in this storage");

            _context.Set<Purchase>().Add(purchase);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete order from DB
        /// </summary>
        /// <param name="purchase">Purchase to delete</param>
        public void DeletePurchase(Purchase purchase)
        {
            var deletedProd = _context.Set<Purchase>().SingleOrDefault(x => x.PurchaseId == purchase.PurchaseId);
            if (deletedProd == null)
                throw new InvalidOperationException($"Purchase №{purchase.PurchaseId} doesn't exist");

            _context.Set<Purchase>().Remove(deletedProd);
            _context.SaveChanges();
        }

        public void UpdatePurchase(Purchase purchase)//id?
        {
            var updatePurchase = _context.Set<Purchase>().SingleOrDefault(x => x.PurchaseId == purchase.PurchaseId);

            updatePurchase.Orders = purchase.Orders;
            _context.SaveChanges();
        }
    }
}
