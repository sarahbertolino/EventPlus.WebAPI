using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{

/// <summary>
/// Interface do repositório para a entidade TipoEvento - Contrato da TipoEvento, Métodos que deverão ser implementados dentro do repositório.
/// </summary>
    public interface ITipoEvento
    {
        Task Cadastrar(TipoEvento tipoEvento);
        Task Atualizar(Guid id, TipoEvento tipoEvento);

        Task Deletar(Guid id);

        Task<List<TipoEvento>> Listar();

        Task<TipoEvento?> BuscarPorId(Guid id);
    }
}
