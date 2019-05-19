using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Logica.Repositorios
{
    public class TarjetaComparador : IEqualityComparer<tarjeta>
    {
        public bool Equals(tarjeta x, tarjeta y)
        {
            if (x.numeroID == y.numeroID)
            {

                return true;
            }

            return false;
        }

        public int GetHashCode(tarjeta obj)
        {
            return obj.GetHashCode();
        }
    }
}
