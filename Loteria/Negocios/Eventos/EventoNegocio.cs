using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo.Repositorios;
//using Logica;
using Datos.Models;

namespace Negocios.Eventos
{
    public class EventoNegocio
    {
        private EventoRepositorio evento_repo;
        private LoteriaModel model;        

        public EventoNegocio()
        {
            evento_repo = new EventoRepositorio();
            model = new LoteriaModel();
        }

        public EventoNegocio(EventoRepositorio repo, LoteriaModel mod)
        {
            evento_repo = repo;
            model = mod;
        }

        //Obtener todos los eventos
        public IEnumerable<evento> All()
        {
            return evento_repo.ListadoEventos();
        }

        //Insertar un evento
        public void InsertarEvento(evento evt)
        {
            evento_repo.Adicionar(evt);
        }

        //Obtener los detalles de un evento dado su ID
        public evento DetallesEvento(string id)
        {
            return GetEventoByID(id);
        }

        //Editar un evento
        public void EditarEvento(evento evt)
        {
            evento_repo.Editar(evt);
        }

        //Obtener un evento dado su ID
        public evento GetEventoByID(string id)
        {
            evento evt = new evento();
            evt = model.evento.Where(x => x.ID == id).FirstOrDefault();
            return evt;
        }

        public void BorrarEventoByID(string id)
        {
            evento_repo.BorrarEvento(id);
        }

        public IEnumerable<tarjeta> TarjetasAsociadasEvento(string id)
        {
            //return GetEventoByID(id).tarjeta.ToList();
            IEnumerable<tarjeta> asociadas = model.tarjeta.Where(x => x.ID == id);
            return asociadas.ToList();

        }

        public void TarjetaGanadora(List<tarjeta> actualizadas)
        {
            foreach (tarjeta item in actualizadas)
            {
                tarjeta existente = model.tarjeta.Find(item.numeroID);
                existente.estado = item.estado;
            }
            model.SaveChanges();
        }

        public bool IsEventoExist(evento evt)
        {
            return evento_repo.Existe(evt);
        }

        public IEnumerable<evento> EventosDisponibles()
        {
            List<evento> eventos_disponibles = new List<evento>();

            DateTime fechaActual = DateTime.Now;
            fechaActual = Convert.ToDateTime(String.Format("{0:yyyy/MM/dd}", fechaActual));

            var horaActual = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            var eventos = All();

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
        }

        public IEnumerable<evento> EventosFinalizados()
        {
            List<evento> eventos_finalizados = new List<evento>();

            DateTime fechaActual = DateTime.Now;
            fechaActual = Convert.ToDateTime(String.Format("{0:yyyy/MM/dd}", fechaActual));

            var horaActual = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            var eventos = All();

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

    }
}
