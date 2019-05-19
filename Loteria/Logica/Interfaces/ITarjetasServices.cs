using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logica.Interfaces
{
   public interface ITarjetasServices
    {
        IEnumerable<evento> ActualizarListaEventos();
    }
}
