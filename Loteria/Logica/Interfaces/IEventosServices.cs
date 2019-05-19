using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Logica.Interfaces
{
    public interface IEventosServices
    {
        IEnumerable<tarjeta> TarjetasAsociadas(string idEvento);
        void ActualizarEstadoTarjetas(List<tarjeta> estados_actualizados);
    }
}
