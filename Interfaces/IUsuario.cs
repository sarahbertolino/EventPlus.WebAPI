using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IUsuario
    {
        Task Cadastrar(Usuario usuario);

        Task Atualizar(Guid id, Usuario usuario);

        Task Deletar(Guid id);

        Task<IEnumerable<Usuario>> Listar();

        Task<Usuario?> BuscarPorId(Guid id);

        Task<Usuario?> BuscarPorEmailESenha(string email, string senha);
    }
}
