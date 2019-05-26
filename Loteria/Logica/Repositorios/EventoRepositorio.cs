using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Repo.Interfaces;
using System.Data.Entity;

namespace Repo.Repositorios
{
    public class EventoRepositorio : IEventoRepository
    {

        LoteriaModel _lotModel;       


        public EventoRepositorio()
        {
            _lotModel = new LoteriaModel();          

        }

        public EventoRepositorio(LoteriaModel lot)
        {
            _lotModel = lot;         

        }

        public void Adicionar(evento evt)
        {
            _lotModel.evento.Add(evt);
            _lotModel.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Editar(evento evt)
        {
            _lotModel.Entry(evt).State = EntityState.Modified;
            _lotModel.SaveChanges();
            //throw new NotImplementedException();
        }
        

        public IEnumerable<evento> ListadoEventos()
        {
            return _lotModel.evento.ToList();
            //throw new NotImplementedException();
        }  
          

        public void BorrarEvento(string id)
        {
            var evt = _lotModel.evento.SingleOrDefault(x => x.ID == id);
            
            var tarjetas_asociadas = evt.tarjeta;

            _lotModel.tarjeta.RemoveRange(tarjetas_asociadas);
            _lotModel.evento.Remove(evt);

            _lotModel.SaveChanges();
            
            //_lotModel.evento.Remove(evt);
            //_lotModel.SaveChanges();            
        }

        public bool Existe(evento evt)
        {
            //throw new NotImplementedException();
            List<evento> listado = ListadoEventos().ToList();
            bool existe = listado.Contains(evt, new EventoComparador());
            return existe;
        }
    }
}
