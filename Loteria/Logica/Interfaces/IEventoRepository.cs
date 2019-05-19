using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Logica.Interfaces
{
    public interface IEventoRepository
    {
        void Adicionar(evento evt);
        IEnumerable<evento> ListadoEventos();
        void Editar(evento evt);
        evento GetEvento(string id);
        IEnumerable<tarjeta> getTarjetasAsociadas(string idEvento);
        IEnumerable<evento> EventosDisponibles();
        IEnumerable<evento> EventosFinalizados();
        void BorrarEvento(string id);
        bool Existe(evento evt);

    }
}
