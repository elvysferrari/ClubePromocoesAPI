using ClubePromocoesAPI.Reads.LojaModule.DTOs;

namespace ClubePromocoesAPI.Reads.LojaModule.Repositories
{
    public interface ILojaQuery
    {
        Task<List<LojaDTO>> ObterTodasAsync(int? pageNumer, int? pageSize);
        Task<LojaDTO> ObterPorIdAsync(int id);
    }
}
