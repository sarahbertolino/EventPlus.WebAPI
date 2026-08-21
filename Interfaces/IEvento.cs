using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IEvento
    {
        Cadastrar(Evento evento);
        List<Evento> Listar();
        Atualizar(Guid id, Evento evento);
        Deletar(Guid id);
        Evento BuscarPorId(Guid id);
        List<Evento> ListarPorInstituicao(Guid idInstituicao);
        List<Evento> ListarPorInscrito(Guid id);
        List<Evento> ListarProximosEvento();
    }
}
