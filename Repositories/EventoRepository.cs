using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class EventoRepository : IEvento
    {
        private readonly EventContext _context = new EventContext();
        public void Atualizar(Guid id, Evento evento)
        {
            var eventoBuscado = _context.Evento.Find(id);
            if (eventoBuscado != null)
            {
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;

                _context.Evento.Update(eventoBuscado);
                _context.SaveChanges();
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            return _context.Evento
                .Include(e => e.TipoEvento)
                .Include(e => e.Instituicao)
                .FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            _context.Evento.Add(evento);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var eventoBuscado = _context.Evento.Find(id);
            if (eventoBuscado != null)
            {
                _context.Evento.Remove(eventoBuscado);
                _context.SaveChanges();
            }
        }

        public List<Evento> Listar()
        {
            return _context.Evento
                .Include(e => e.TipoEvento)
                .Include(e => e.Instituicao)
                .ToList();
        }

        public List<Evento> ListarPorInscrito(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> ListarPorInstituicao(Guid idInstituicao)
        {
            return _context.Evento
                .Where(e => e.IdInstituicao == idInstituicao)
                .Include(e => e.IdTipoEvento)
                .ToList();
        }

        public List<Evento> ListarProximosEvento()
        {
            return _context.Evento
                .Where(e => e.DataEvento >= DateTime.Now)
                .OrderBy(e => e.DataEvento)
                .Include(e => e.TipoEvento)
                .Include(e => e.Instituicao)
                .ToList();
        }
    }
}
