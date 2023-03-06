using ClubePromocoesAPI.Domain.Entities;

namespace ClubePromocoesAPI.Domain.Interfaces
{
    public interface IPromocao: IRepository<Promocao>
    {       
        Task<Promocao> ObterPorIdAsync(long id);
    }
}
