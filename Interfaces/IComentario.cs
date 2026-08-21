using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public class IComentario
    {
        Cadastrar(Comentario comentario);
        Deletar(Guid id);
        List<Comentario> Listar();
        List<Comentario> ListarPorEvento(Guid idEvento);
        Comentario BuscarPorId(Guid id);
    }
}
