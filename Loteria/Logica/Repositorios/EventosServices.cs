using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Logica.Interfaces;
using System.Data.Entity;

namespace Logica.Repositorios
{
    public class EventosServices : IEventosServices
    {
        private LoteriaModel lotModel = new LoteriaModel();

        public void ActualizarEstadoTarjetas(List<tarjeta> estados_actualizados)
        {
               
                foreach (tarjeta item in estados_actualizados) {
                    tarjeta existente = lotModel.tarjeta.Find(item.numeroID);
                    existente.estado = item.estado;
                }

            lotModel.SaveChanges();        
            
        }

        public IEnumerable<tarjeta> TarjetasAsociadas(string idEvento)
        {
            IEnumerable<tarjeta> asociadas = lotModel.tarjeta.Where(x => x.ID == idEvento);
            return asociadas;
            //throw new NotImplementedException();
        }
        
    }
}
