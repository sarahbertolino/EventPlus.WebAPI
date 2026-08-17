using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;

namespace EventPlus.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EventContext _context;
        
        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }
        public Task Atualizar(Guid id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> BuscarPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Cadastrar(Usuario usuario)
        {
            // criptografamos a senha antes de salvar no banco de dados
            usuario.Senha = Criptografia.GerarHash(usuario.Senha);

            await _context.Usuario.AddAsync(usuario);

            await _context.SaveChangesAsync();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
