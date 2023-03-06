using ClubePromocoesAPI.Reads.PromocaoModule.DTOs;

namespace ClubePromocoesAPI.Reads.PromocaoModule.Repositories
{
    public interface IPromocaoQuery
    {
        Task<List<PromocaoDTO>> ObterTodasAsync(int? pageNumer, int? pageSize);
        Task<PromocaoDTO> ObterPorIdAsync(int id);
    }
}
