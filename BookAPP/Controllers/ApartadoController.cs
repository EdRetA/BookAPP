using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookAPP.Controllers
{
    public class ApartadoController : Controller
    {
        // GET: Apartado
        public ActionResult Index()
        {
            return View();
        }

        // GET: Apartado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Apartado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apartado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Apartado/Edit/5
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

        // GET: Apartado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Apartado/Delete/5
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
