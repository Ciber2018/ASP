using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Logica.Interfaces
{
    public interface ITarjetaRepository
    {
        void Adicionar(tarjeta tarj);
        void ActualizarTarjetaByID(int tarjetaID);
        bool ExisteTarjeta(tarjeta tarj);        
        
    }
}
