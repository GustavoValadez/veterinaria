using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boutique.Web.Models;
using Microsoft.AspNet.Identity;

namespace Boutique.Web.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AllOrders()
        {
            var orders = db.Orders.Include(c=>c.Client.ApplicationUser).Include(a=>a.Article).ToList();
            //var orders = db.Orders.Include(a=>a.Article.ArticleName).ToList();
            return View(orders);
        }






        // GET: Orders
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var cl = db.Clients.Where(c => c.UserId == user).FirstOrDefault();
            var orders = db.Orders.Include(u => u.Client).Where(c => c.ClientId == cl.Id).ToList();


            return View(orders);

            //var orders = db.Orders.Include(o => o.Article);
            //return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            //return View();


            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "ArticleName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                // Si esta autenticado un Cliente
                var userId = User.Identity.GetUserId();
                // Para traer al user de la base de datos
                var cli = db.Clients.Where(c => c.UserId == userId).FirstOrDefault();
                // Agregamos el Id del cli que buscamos
                order.ClientId = cli.Id;

                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ArticleId = new SelectList(db.Articles, "Id", "ArticleName", order.ArticleId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "ArticleName", order.ArticleId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "ArticleName", order.ArticleId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
