using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica.Repositorios;
using Datos.Models;


namespace Web.Controllers
{
    public class TarjetaController : Controller
    {
        TarjetaRepository repo = new TarjetaRepository();
        TarjetaServices services = new TarjetaServices();
        EventoRepositorio evt_repo = new EventoRepositorio();


        // GET: Tarjeta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult CreateTarjeta()
        {
            /*var model = new tarjeta {
                eventoCollection = services.ActualizarListaEventos()
            };*/
            var eventos = services.ActualizarListaEventos();
            SelectList lista = new SelectList(eventos,"ID","ID");
            ViewBag.ListaEventos = lista;

            return View(new tarjeta());
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult CreateTarjeta(tarjeta nueva)
        {
            repo.Adicionar(nueva);

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