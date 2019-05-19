using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Logica.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Logica.Repositorios
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private LoteriaModel mod;
        
        
        public TarjetaRepository()
        {
            mod = new LoteriaModel();
        }

        public void ActualizarTarjetaByID(int tarjetaID)
        {
            //throw new NotImplementedException();
            tarjeta tarj = mod.tarjeta.Where(x => x.numeroID == tarjetaID).FirstOrDefault();
            
        }

        public void Adicionar(tarjeta tarj)
        {
            //var objectContext = ((IObjectContextAdapter)mod).ObjectContext;
            /*tarjeta nueva = new tarjeta()
            {
                numeroID = tarj.numeroID,
                ID = tarj.ID,
                estado = null,
                evento = null
            };*/
            //mod.tarjeta.Add(tarj);
            mod.Entry(tarj).State = EntityState.Added;
            mod.SaveChanges();
            //throw new NotImplementedException();
        }

        public bool ExisteTarjeta(tarjeta tarj)
        {
            List<tarjeta> listado = mod.tarjeta.ToList();
            return listado.Contains(tarj, new TarjetaComparador());
        }       

    }
}
