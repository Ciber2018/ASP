using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica.Repositorios;
using Logica;
using Datos.Models;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ValuesController : ApiController
    {

        private EventoRepositorio repo_evento = new EventoRepositorio();
        private LoteriaModel lotModel = new LoteriaModel();
        private EventosServices services = new EventosServices();


        // GET api/values/GetAllEvent          
        public IEnumerable<evento> GetAllEvents()
        {            
            //return new string[] { "value1", "value2" };
            //List<evento> evt = repo_evento.ListadoEventos().ToList();
            return repo_evento.ListadoEventos().ToList();
            //return evt;
        }

        // GET api/values/GetEventosDisponibles
        public IEnumerable<evento> GetEventosDisponibles()
        {

            return repo_evento.EventosDisponibles().ToList();
        }

        // GET api/values/GetEventosFinalizados
        public IEnumerable<evento> GetEventosFinalizados()
        {
            return repo_evento.EventosFinalizados().ToList();
        }

        public IEnumerable<tarjeta> GetTarjetasAsociadas(string id)
        {
            return services.TarjetasAsociadas(id).ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
