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
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article, HttpPostedFileBase hpb)
        {
            if (ModelState.IsValid)
            {

                if (hpb != null)
                {
                    var perfil = System.IO.Path.GetFileName(hpb.FileName);
                    var direccion = "~/Content/img/" + article.ArticleName + "_" + perfil;
                    hpb.SaveAs(Server.MapPath(direccion));
                    article.ImgUrl = article.ArticleName + "_" + perfil;
                }



                //Si esta autenticado un Cliente
                var userId = User.Identity.GetUserId();
                //Para Traer el Usuario de la bd.
                var cli = db.Clients.Where(c => c.UserId == userId).FirstOrDefault();
                //Agregamos el Id del Own que buscamos
                //article.ClientId = cli.Id;

                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
               


                //db.Articles.Add(article);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article, HttpPostedFileBase hpb)
        {
            if (ModelState.IsValid)
            {
                ////////////////////////////////////////////////////////////////
                // Para poder agregar la imagen al perfl de cada mascota
                if (hpb != null)
                {
                    var perfil = System.IO.Path.GetFileName(hpb.FileName);
                    var direccion = "~/Content/img/" + article.ArticleName + "_" + perfil;
                    hpb.SaveAs(Server.MapPath(direccion));
                    article.ImgUrl = article.ArticleName + "_" + perfil;
                }
                ///////////////////////////////////////////////////////////////
                // Esto solo funciona si esta autenticado
                var userId = User.Identity.GetUserId();
                // Esto funciona para traer el Usuario de la Base de Datos.
                var cli = db.Clients.Where(o => o.UserId == userId).FirstOrDefault();
                // Agregamos el Id del Own que buscamos
                //article.ClientId = cli.Id;


                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");



                //db.Entry(article).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
