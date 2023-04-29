using BookAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookAPP.Controllers
{
    public class VlibrousuarioController : Controller
    {
        // GET: vlibrousuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult buscar()
        {
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
    }
}