using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EventContext _context;
        
        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }
        public async Task Deletar(Guid id)
        {
            var UsuarioBuscado = await
            _context.Usuario.FindAsync(id);
            if (UsuarioBuscado != null)
            {
                _context.Usuario.Remove(UsuarioBuscado);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Atualizar(Guid id, Usuario usuario)
        {
            var UsuarioBuscado = await _context.Usuario.FindAsync(id); // vem do Guid
            if (UsuarioBuscado != null) // null ou objeto encontrado
            {

                UsuarioBuscado.Nome = usuario.Nome; // substituir  o titulo do objeto buscado pelo titulo do novo objeto
                UsuarioBuscado.Email = usuario.Email;
                UsuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;

                if (!string.IsNullOrEmpty(usuario.Senha))
                {
                    UsuarioBuscado.Senha = Criptografia.GerarHash(usuario.Senha);
                }

                _context.Usuario.Update(UsuarioBuscado);
                await _context.SaveChangesAsync();
            }

             
        }

        public async Task<Usuario?> BuscarPorEmailESenha(string email, string senha)
        {
            var usuario = await _context.Usuario
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstAsync(u => u.Email == email);
            if (usuario == null)
            {
                return null;
            }

            // verifica se a senha digitada corresponde ao hash salvo no banco
            bool senhaValida = Criptografia.CompararHash(senha, usuario.Senha);

            if (!senhaValida)
            {
                return null;
            }
            return usuario;
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(t => t.IdUsuario == id);
        }

        public async Task Cadastrar(Usuario usuario)
        {
            // criptografamos a senha antes de salvar no banco de dados
            usuario.Senha = Criptografia.GerarHash(usuario.Senha);

            await _context.Usuario.AddAsync(usuario);

            await _context.SaveChangesAsync();
        }


        public async Task<List<Usuario>> Listar()
        {
            //return await _context.Usuario.AsNoTracking().ToListAsync();

            return await _context.Usuario
                .Include(u => u.IdTipoUsuarioNavigation)
                .AsNoTracking()
                .ToListAsync();

        }

    }
}
