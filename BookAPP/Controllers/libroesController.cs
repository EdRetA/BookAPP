using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookAPP.Models;

namespace BookAPP
{
    public class libroesController : Controller
    {
        private libreriaEntities1 db = new libreriaEntities1();

        // GET: libroes
        public ActionResult Index()
        {
            return View(db.libros.ToList());
        }

        // GET: libroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: libroes/Create
        public ActionResult Create()
        {
            return View();
        }

        //public ActionResult Reserva()
        //{
        //    return RedirectToAction("Create", "Apartado");
        //}
        public ActionResult Reserva(int? id)
        {

            return RedirectToAction("Create", "Apartado",id);
        }

        // POST: libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,empresa,precio,stock,reservas")] libro libro)
        {
            if (ModelState.IsValid)
            {
                db.libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        // GET: libroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,empresa,precio,stock,reservas")] libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        // GET: libroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            libro libro = db.libros.Find(id);
            db.libros.Remove(libro);
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
