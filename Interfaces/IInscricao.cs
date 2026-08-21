using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IInscricao
    {
        void Inscrever(Presenca presenca);
        void AtualizarSituacao(Guid id, bool situacao);
        List<Presenca> Listar();
        List<Presenca> ListarMinhasPresencas(Guid idUsuario);
        Presenca BuscarPorId(Guid id);
    }
}
