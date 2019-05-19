using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Logica.Interfaces;
using System.Data.Entity;

namespace Logica.Repositorios
{
    public class EventoRepositorio : IEventoRepository
    {
        LoteriaModel _lotModel;
        EventosServices _evtServices;


        public EventoRepositorio()
        {
            _lotModel = new LoteriaModel();
            _evtServices = new EventosServices();

        }

        public EventoRepositorio(LoteriaModel lot, EventosServices serv)
        {
            _lotModel = lot;
            _evtServices = serv;

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

        public evento GetEvento(string id)
        {
            evento evt = new evento();
            evt = _lotModel.evento.Where(x => x.ID == id).FirstOrDefault();
            return evt;
            //throw new NotImplementedException();            
        }

        public IEnumerable<evento> ListadoEventos()
        {
            return _lotModel.evento.ToList();
            //throw new NotImplementedException();
        }

        public IEnumerable<tarjeta> getTarjetasAsociadas(string idEvento)
        {
            return _evtServices.TarjetasAsociadas(idEvento);
                        
            //throw new NotImplementedException();
        }

        public IEnumerable<evento> EventosDisponibles()
        {
            List<evento> eventos_disponibles = new List<evento>();

            DateTime fechaActual = DateTime.Now;
            fechaActual = Convert.ToDateTime(String.Format("{0:yyyy/MM/dd}", fechaActual));

            var horaActual = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            var eventos = ListadoEventos();

            for (int i = 0; i < eventos.Count(); i++)
            {
                var fechaElemento = Convert.ToDateTime(eventos.ElementAt(i).fecha);
                var horaElemento = Convert.ToDateTime(eventos.ElementAt(i).hora);

                if (fechaElemento > fechaActual.Date)
                {
                    eventos_disponibles.Add(eventos.ElementAt(i));
                }
                else
                {
                    if (fechaElemento == fechaActual.Date && horaElemento > horaActual)
                    {
                        eventos_disponibles.Add(eventos.ElementAt(i));
                    }
                }
            }

            return eventos_disponibles;
       
            //throw new NotImplementedException();
        }

        public IEnumerable<evento> EventosFinalizados()
        {
            List<evento> eventos_finalizados = new List<evento>();

            DateTime fechaActual = DateTime.Now;
            fechaActual = Convert.ToDateTime(String.Format("{0:yyyy/MM/dd}", fechaActual));

            var horaActual = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            var eventos = ListadoEventos();

            for (int i = 0; i < eventos.Count(); i++)
            {
                var fechaElemento = Convert.ToDateTime(eventos.ElementAt(i).fecha);
                var horaElemento = Convert.ToDateTime(eventos.ElementAt(i).hora);

                if (fechaElemento < fechaActual.Date)
                {
                    eventos_finalizados.Add(eventos.ElementAt(i));
                }
                else
                {
                    if (fechaElemento == fechaActual.Date && horaElemento < horaActual)
                    {
                        eventos_finalizados.Add(eventos.ElementAt(i));
                    }
                }
            }

            return eventos_finalizados;
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
