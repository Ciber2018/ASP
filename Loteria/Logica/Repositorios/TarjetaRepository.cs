using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Repo.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repo.Repositorios
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private LoteriaModel mod;
        
        
        public TarjetaRepository()
        {
            mod = new LoteriaModel();
        }        

        public void Adicionar(tarjeta tarj)
        {
            //mod.tarjeta.Add(tarj);
            mod.Entry(tarj).State = EntityState.Added;
            mod.SaveChanges();
        }              

    }
}
