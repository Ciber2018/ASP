using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos.Models;
using Negocios.Eventos;
using System.Web.Http.Description;
using System.Web.Http.Cors;



namespace API.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ValuesController : ApiController
    {

        private EventoNegocio evt_negocio = new EventoNegocio();


        // GET api/values/GetAllEvent          
        public IEnumerable<evento> GetAllEvents()
        {                        
            return evt_negocio.All();            
        }

        // GET api/values/GetEventosDisponibles
        public IEnumerable<evento> GetEventosDisponibles()
        {
            return evt_negocio.EventosDisponibles();
        }

        // GET api/values/GetEventosFinalizados
        public IEnumerable<evento> GetEventosFinalizados()
        {
            return evt_negocio.EventosFinalizados();
        }

        public IEnumerable<tarjeta> GetTarjetasAsociadas(string id)
        {
            return evt_negocio.TarjetasAsociadasEvento(id);
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
