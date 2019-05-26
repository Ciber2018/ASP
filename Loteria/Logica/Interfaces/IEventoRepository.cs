using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Repo.Interfaces
{
    public interface IEventoRepository
    {
        void Adicionar(evento evt);
        IEnumerable<evento> ListadoEventos();
        void Editar(evento evt);           
        void BorrarEvento(string id);
        bool Existe(evento evt);

    }
}
