using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookAPP.Models;

namespace BookAPP.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(libroModel libroD)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    libroDal entdb = new libroDal();
                    string resp = entdb.AgregarLibro(libroD);
                    ViewBag.Estado = 1;
                    ModelState.Clear();
                    return View("Create");
                }
                else
                {
                    ViewBag.Estado = 2;
                    return View("Create");
                }
                
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        // GET: Libro/Create
        public ActionResult Ingreso()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Ingreso(libroModel libroD)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    libroDal entdb = new libroDal();
                    string resp = entdb.AgregarLibro(libroD);
                    ViewBag.Estado = 1;
                    ModelState.Clear();
                    return View("Ingreso");
                }
                else
                {
                    ViewBag.Estado = 2;
                    return View("Ingreso");
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
