using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;

namespace ClubePromocoesAPI.Reads.UsuarioModule.Repositories
{
    public interface IUsuarioQuery
    {
        Task<UsuarioAutenticadoDTO> ObterPorIdAsync(int id);
        Task<UsuarioAutenticadoDTO> ValidaLogin(string email, string password);
        Task<string> Adicionar(string nome, string email, string password, DateTime criado_em);
    }
}
