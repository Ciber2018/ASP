using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Repo.Repositorios
{
    public class EventoComparador : IEqualityComparer<evento>
    {
        public bool Equals(evento x, evento y)
        {
            
            if (x.ID == y.ID)
            {

                return true;
            }

            return false;
        }      

        public int GetHashCode(evento obj)
        {
            return obj.GetHashCode();
        }      

    }
}
