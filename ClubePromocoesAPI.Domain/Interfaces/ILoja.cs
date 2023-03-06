using ClubePromocoesAPI.Domain.Entities;

namespace ClubePromocoesAPI.Domain.Interfaces
{
    public interface ILoja: IRepository<Loja>    
    {
        Task<Loja> ObterPorIdAsync(long id);
    }
}
