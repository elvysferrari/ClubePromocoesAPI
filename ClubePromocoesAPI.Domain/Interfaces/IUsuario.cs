using ClubePromocoesAPI.Domain.Entities;

namespace ClubePromocoesAPI.Domain.Interfaces
{
    public interface IUsuario : IRepository<Usuario>
    {
        Task<Usuario> ObterPorIdAsync(int id);         
    }
}
