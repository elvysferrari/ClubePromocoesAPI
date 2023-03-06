using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using ClubePromocoesAPI.Reads.UsuarioModule.Queries;
using ClubePromocoesAPI.Reads.UsuarioModule.Repositories;
using MediatR;

namespace ClubePromocoesAPI.Reads.UsuarioModule.Handler
{
    public class ObterUsuarioPorIdHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioAutenticadoDTO>
    {
        private readonly IUsuarioQuery _usuarioQuery;
        public ObterUsuarioPorIdHandler(IUsuarioQuery usuarioQuery)
        {
            _usuarioQuery = usuarioQuery;
        }
        public async Task<UsuarioAutenticadoDTO> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioQuery.ObterPorIdAsync(request.Id);
        }
    }
}
