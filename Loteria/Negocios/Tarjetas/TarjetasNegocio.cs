using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Repo.Repositorios;
using Negocios.Eventos;

namespace Negocios.Tarjetas
{
    public class TarjetasNegocio
    {
        private TarjetaRepository tarj_repositorio;
        private EventoNegocio evt_negocio;

        public TarjetasNegocio()
        {
            tarj_repositorio = new TarjetaRepository();
            evt_negocio = new EventoNegocio();
        }

        public TarjetasNegocio(TarjetaRepository tarj,EventoNegocio evt)
        {
            tarj_repositorio = tarj;
            evt_negocio = evt;
        }

        public void InsertarTarjeta(tarjeta tarj)
        {
            tarj_repositorio.Adicionar(tarj); 
        }

        public IEnumerable<evento> ListadoEventos()
        {
            return evt_negocio.All();
        }
        
    }
}
