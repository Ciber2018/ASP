using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using Negocios.Tarjetas;


namespace Web.Controllers
{
    public class TarjetaController : Controller
    {
       
        TarjetasNegocio tarj_negocio = new TarjetasNegocio();


        // GET: Tarjeta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult CreateTarjeta()
        {
            var eventos = tarj_negocio.ListadoEventos();
            SelectList lista = new SelectList(eventos,"ID","ID");
            ViewBag.ListaEventos = lista;

            return View(new tarjeta());
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult CreateTarjeta(tarjeta nueva)
        {
            //repo.Adicionar(nueva);
            tarj_negocio.InsertarTarjeta(nueva);

            return RedirectToAction("CreateTarjeta");

            /*if (repo.ExisteTarjeta(nueva))
            {
                ViewBag.Error = "Evento ya existe";
                return View(nueva);
            }
            else
            {
                if (ModelState.IsValid)
                {
                   repo.Adicionar(nueva);
                }
                ViewBag.Success = "Evento Creado Satisfactoriamente";
            }

            return View(nueva);*/
        }
    }
}