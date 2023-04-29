using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookAPP.Models;

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
            PopulateDropDownList();
            return View();
        }

        // POST: Apartado/Create
        [HttpPost]
        public ActionResult Create(apartadoModel apartadoD)
        {
            try
            {
                apartadoD.fklibro = apartadoD.id;
                apartadoD.estado = false;
                                    
                    apartadoDal entdb = new apartadoDal();
                    string resp = entdb.AgregarApartado(apartadoD);
                    
                    ModelState.Clear();
                ViewBag.Estado = 1;
                //PopulateDropDownList();
                return RedirectToAction("Index","Libroes");
                //return View("Create");


            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Apartado/Edit/5
        public ActionResult Edit(int id)        {
            
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

        private void PopulateDropDownList()
        {
            apartadoDal entdb = new apartadoDal();
            List<string> items = entdb.BuscarClientes();
            ViewBag.Items = items;
        }

        public ActionResult Actualizar()
        {
            RetirarLibros();


            //apartadoDal entdb = new apartadoDal();
            //List<string> items = entdb.BuscarClientes();
            //ViewBag.Items = items;
            
            return Redirect("Buscar");
        }



        [HttpPost]
        public ActionResult Actualizar(apartadoModel entradaD)
        {
            apartadoDal entdb = new apartadoDal();
            List<string> items = entdb.BuscarClientes();
            ViewBag.Items = items;
            return View();
        }
        public ActionResult buscar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult buscar(apartadoModel entradaD)
        {
            apartadoDal entdb = new apartadoDal();
            List<vlibrousuarioModel> items = entdb.BuscarEntrada(entradaD);
            ViewBag.entradas = items;
            return View();
        }

        [HttpPost]
        public ActionResult BuscarEntrada(vlibrousuarioModel entradaD)
        {
            vlibrousuarioDal entdb = new vlibrousuarioDal();
            List<vlibrousuarioModel> items = entdb.BuscarEntrada(entradaD);
            ViewBag.entradas = items;
            return View();
        }




        private void RetirarLibros()
        {
            //libroModel libroD = new libroModel();
            apartadoModel apartadoD = new apartadoModel();            
            string codigo = Request.QueryString["idapartado"];            
            apartadoD.id = Convert.ToInt32(codigo);

            apartadoDal entdb = new apartadoDal();
                        entdb.cambiarestado(apartadoD);           
          

        }





    }
}
