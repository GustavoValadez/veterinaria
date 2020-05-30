﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Controllers
{
    public class PetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Para que el Admin pueda ver las mascotas del cliente
        public ActionResult AllPets()
        {
            var pets = db.Pets.Include(o => o.Owner).Include(u=>u.Owner.ApplicationUser).ToList();

            return View(pets);
        }

        // GET: Pets
        public ActionResult Index()
        {

            var user = User.Identity.GetUserId();
            var ow = db.Owners.Where(o => o.UserId == user).FirstOrDefault();
            var pets = db.Pets.Include(u => u.Owner).Where(p => p.OwnerId == ow.Id).ToList();
            


            return View(pets);
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet, HttpPostedFileBase hpb)
        {
            if (ModelState.IsValid)
            {
                ////////////////////////////////////////////////////////////////
                // Para poder agregar la imagen al perfl de cada mascota
                if (hpb != null)
                {
                    var perfil = System.IO.Path.GetFileName(hpb.FileName);
                    var direccion = "~/Content/img/" + pet.Name + "_" + perfil;
                    hpb.SaveAs(Server.MapPath(direccion));
                    pet.ImgUrl = pet.Name + "_" + perfil;
                }
                ///////////////////////////////////////////////////////////////
                
                // Esto solo funciona si esta autenticado
                var userId = User.Identity.GetUserId();
                // Esto funciona para traer el Usuario de la Base de Datos.
                var own = db.Owners.Where(o => o.UserId == userId).FirstOrDefault();
                // Agregamos el Id del Own que buscamos
                pet.OwnerId = own.Id; 

                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pet pet, HttpPostedFileBase hpb)
        {
            /////////////////////////////////////////////////////////////////////////////////////////
            ///////////// Esto aparecia antes de modificar para editar imagen de perfil /////////////
            //if (ModelState.IsValid)
            //{
            //    db.Entry(pet).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(pet);
            ////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////
            //////////// Esto se lo agregue parecido al Create /////////////////////////////////////




            if (ModelState.IsValid)
            {
                ////////////////////////////////////////////////////////////////
                // Para poder agregar la imagen al perfl de cada mascota
                if (hpb != null)
                {
                    var perfil = System.IO.Path.GetFileName(hpb.FileName);
                    var direccion = "~/Content/img/" + pet.Name + "_" + perfil;
                    hpb.SaveAs(Server.MapPath(direccion));
                    pet.ImgUrl = pet.Name + "_" + perfil;
                }
                ///////////////////////////////////////////////////////////////
                // Esto solo funciona si esta autenticado
                var userId = User.Identity.GetUserId();
                // Esto funciona para traer el Usuario de la Base de Datos.
                var own = db.Owners.Where(o => o.UserId == userId).FirstOrDefault();
                // Agregamos el Id del Own que buscamos
                pet.OwnerId = own.Id;










                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);

        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
