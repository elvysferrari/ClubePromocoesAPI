using ClubePromocoesAPI.Reads.LojaModule.DTOs;
using ClubePromocoesAPI.Reads.LojaModule.Queries;
using ClubePromocoesAPI.Reads.LojaModule.Repositories;
using MediatR;

namespace ClubePromocoesAPI.Reads.LojaModule.Handler
{
    public class ObterLojaPorIdHandler : IRequestHandler<ObterLojaPorIdQuery, LojaDTO>
    {
        private readonly ILojaQuery _lojaQuery;
        public ObterLojaPorIdHandler(ILojaQuery lojaQuery)
        {
            _lojaQuery = lojaQuery;
        }
        public async Task<LojaDTO> Handle(ObterLojaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _lojaQuery.ObterPorIdAsync(request.Id);
        }
    }
}
