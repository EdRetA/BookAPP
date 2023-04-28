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

        public ActionResult ingreso()

        {
            CargarLibro();
            PopulateDropDownList();
            return View(ViewBag.Items[0]);            
        }

        private void PopulateDropDownList()
        {
            libroModel libroM = new libroModel();
            libroM.codigo = Convert.ToInt32(Request.QueryString["codigo"]);
            libroDal entdb = new libroDal();
            List<string> items = entdb.ConsultarApartados(libroM);
            ViewBag.Reservas = items;
        }


        private void CargarReservas()
        {
            throw new NotImplementedException();
        }




        // POST: Libro/Ingreso
        [HttpPost]
        public ActionResult Ingreso(libroModel libroD)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                                       
                        libroDal entdb = new libroDal();
                        string resp = entdb.ActualizarLibro(libroD);
                        ViewBag.Estado = 1;
                        ModelState.Clear();
                        return RedirectToAction("Index", "libroes");                  
                    

                   
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

        private void CargarLibro()
        {
            libroModel  libroD = new libroModel();
            string codigo = Request.QueryString["codigo"];
            string nombre = Request.QueryString["nombre"];
            string empresa = Request.QueryString["empresa"];
            string precio = Request.QueryString["precio"];
            string stock = Request.QueryString["stock"];
            string reservas = Request.QueryString["reservas"];
            libroD.codigo = Convert.ToInt32(codigo);
            libroD.nombre = nombre;
            libroD.empresa = empresa;
            libroD.precio = Convert.ToInt32(precio);
            libroD.stock = Convert.ToInt32(stock);
            libroD.reservas = Convert.ToInt32(reservas);

            List<libroModel> items = new List<libroModel>();
            items.Add(libroD);
            ViewBag.Items = items;


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
