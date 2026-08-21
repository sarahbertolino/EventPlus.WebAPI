using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EventContext _context;

        public InstituicaoRepository(EventContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Guid id, Instituicao instituicao)
        {
            var InstituicaoBuscada = await _context.Instituicao.FindAsync(id); // vem do Guid
            if (InstituicaoBuscada != null) // null ou objeto encontrado
            {

                InstituicaoBuscada.Cnpj = instituicao.Cnpj; // substituir  o titulo do objeto buscado pelo titulo do novo objeto
                InstituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                InstituicaoBuscada.Endereco = instituicao.Endereco;


                _context.Instituicao.Update(InstituicaoBuscada);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Instituicao?> BuscarPorId(Guid id)
        {
            return await _context.Instituicao.FirstOrDefaultAsync(t => t.IdInstituicao == id);
        }

        public async Task Cadastrar(Instituicao instituicao)
        {
            await _context.Instituicao.AddAsync(instituicao);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var InstituicaoBuscada = await
            _context.Instituicao.FindAsync(id);
            if (InstituicaoBuscada != null)
            {
                _context.Instituicao.Remove(InstituicaoBuscada);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Instituicao>> Listar()
        {
            return await _context.Instituicao.AsNoTracking().ToListAsync();
        }
    }
}
