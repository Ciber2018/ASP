using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Logica.Interfaces;
using System.Web.Mvc;



namespace Logica.Repositorios
{
    public class TarjetaServices : ITarjetasServices
    {
        LoteriaModel _lotModel;

        public TarjetaServices()
        {
            _lotModel = new LoteriaModel();
        }

        public TarjetaServices(LoteriaModel model)
        {
            _lotModel = model;
        }

        public IEnumerable<evento> ActualizarListaEventos()
        {
            
            List<evento> eventos = _lotModel.evento.ToList();
            return eventos;            
        }
    }


}
