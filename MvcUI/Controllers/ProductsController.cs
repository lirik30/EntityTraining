using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcUI.Infrastructure.Mappers;
using MvcUI.Models;
using Task;
using Task.Services;

namespace MvcUI.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService _service = new ProductService(new ShopContext());//ninject\

        // GET: Products
        public ActionResult Index()
        {
            return View(_service.GetAllProducts().Select(user => user.ToMvcProduct()).ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(string title)
        {
            if (title == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = _service.GetProductEntity(title);
            if (product == null)
                return HttpNotFound();

            return View(product.ToMvcProduct());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Price")] MvcProduct mvcProduct)
        {
            if (ModelState.IsValid)
            {
                _service.CreateProduct(mvcProduct.ToEntityProduct());
                return RedirectToAction("Index");
            }

            return View(mvcProduct);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string title)
        {
            if (title == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = _service.GetProductEntity(title);
            if (product == null)
                return HttpNotFound();

            return View(product.ToMvcProduct());
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Description,Price")] MvcProduct mvcProduct)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateProduct(mvcProduct.ToEntityProduct());
                return RedirectToAction("Index");
            }
            return View(mvcProduct);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string title)
        {
            if (title == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = _service.GetProductEntity(title);
            if (product == null)
                return HttpNotFound();

            return View(product.ToMvcProduct());
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string title)
        {
            var product = _service.GetProductEntity(title);
            _service.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
