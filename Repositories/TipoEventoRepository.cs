using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoEventoRepository : ITipoEvento
    {
        private readonly EventContext _context;

        public TipoEventoRepository(EventContext context)
        {
            _context = context;
        }
      
        public Task Atualizar(Guid id, TipoEvento tipoEvento)
        {
            throw new NotImplementedException();
        }

        public Task<TipoEvento?> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Cadastrar(TipoEvento tipoEvento)
        {
            await _context.TipoEvento.AddAsync(tipoEvento);
            await _context.SaveChangesAsync();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoEvento>> Listar()
        {
            return await _context.TipoEvento.AsNoTracking().ToListAsync();
        }
    }
}

//public async Task Cadastrar(TipoEvento tipoEvento)
//{
//        await _context.TipoEvento.AddAsync(tipoEvento);
//        await _context.SaveChangesAsync();
//}

//public async Task<List<TipoEvento>> Listar()
//{
//    return await _context.TipoEvento.AsNoTracking().ToListAsync();
//}