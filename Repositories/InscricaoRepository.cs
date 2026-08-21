using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class InscricaoRepository : IInscricao
    {
        private readonly EventContext _context = new EventContext();
        public void AtualizarSituacao(Guid id, bool situacao)
        {
            var presencaBuscada = _context.Presenca.Find(id);
            if (presencaBuscada != null)
            {
                presencaBuscada.Situacao = situacao;
                _context.Presenca.Update(presencaBuscada);
                _context.SaveChanges();
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            return _context.Presenca
                .Include(p => p.Usuario)
                .Include(p => p.Evento)
                .FirstOrDefault(p => p.IdPresenca == id)!;
        }

        public void Inscrever(Presenca presenca)
        {
            _context.Presenca.Add(presenca);
            _context.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return _context.Presenca
                .Include(p => p.Usuario)
                .Include(p => p.Evento)
                .ToList();
        }

        public List<Presenca> ListarMinhasPresencas(Guid idUsuario)
        {
            return _context.Presenca
                .Where(p => p.IdUsuario == idUsuario)
                .Include(p => p.Evento)
                .ThenInclude(e => e!.Instituicao)
                .ToList();
        }
    }
}
