using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using Negocios.Eventos;



namespace Web.Controllers
{
    public class EventoController : Controller
    {

        private EventoNegocio evt_negocio = new EventoNegocio();


        // GET: Evento
        public ActionResult Index()
        {
            IEnumerable<evento> evento_listado = evt_negocio.All();
            return View(evento_listado);
        }

        // GET: Evento/CreateEvento
        public ActionResult CreateEvento()
        {
            return View();            
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult CreateEvento(evento nuevo)
        {
            // TODO: Add insert logic here
            if (evt_negocio.IsEventoExist(nuevo))
            {
                ViewBag.Error = "Evento ya existe";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    evt_negocio.InsertarEvento(nuevo);
                }
                ViewBag.Success = "Evento Creado Satisfactoriamente";
            }
                
            return View();
           
        }

        // GET: Default/Details/5
        public ActionResult Details(string id)
        {
            if (evt_negocio.TarjetasAsociadasEvento(id).Count() == 0)
            {
                ViewBag.Info = "No existen tarjetas asociadas a este evento";
                ViewData["tarjetas_asociadas"] = evt_negocio.TarjetasAsociadasEvento(id);
                return View(evt_negocio.DetallesEvento(id));
            }

            ViewData["tarjetas_asociadas"] = evt_negocio.TarjetasAsociadasEvento(id);
            return View(evt_negocio.DetallesEvento(id));
        }        


        // GET: Default/Edit/5
        public ActionResult EditarEvento(string id)
        {
            return View(evt_negocio.GetEventoByID(id));
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult EditarEvento(evento evt)
        {
            try
            {
                evt_negocio.EditarEvento(evt);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(string id)
        {
            evt_negocio.BorrarEventoByID(id);
            return RedirectToAction("Index");
        }

        // POST: Default/Delete/5
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

        // GET: Evento/TarjetaGanadora/
        public ActionResult TarjetaGanadora(string id)
        {
            
            //ViewData["estados"] = tarj_repo.listarEstados();
            return View(evt_negocio.TarjetasAsociadasEvento(id)); 
        }


        [HttpPost]
        public ActionResult TarjetaGanadora(List<tarjeta> tarjeta)
        {
            int contador = 0;
            for (int i = 0; i < tarjeta.Count(); i++)
            {
                if (tarjeta.ElementAt(i).estado == "W")
                {
                    contador++;
                }

            }

            if (contador > 1)
            {
                ViewBag.Error = "Puede escoger solamente una tarjeta como ganadora";
                return View(tarjeta);
            }
            else
            {
                evt_negocio.TarjetaGanadora(tarjeta);
            }
            

            //ViewData["estados"] = tarj_repo.listarEstados();
            return RedirectToAction("TarjetaGanadora");
        }

    }
}