using ClubePromocoesAPI.Reads.PromocaoModule.DTOs;
using ClubePromocoesAPI.Reads.PromocaoModule.Queries;
using ClubePromocoesAPI.Reads.PromocaoModule.Repositories;
using MediatR;

namespace ClubePromocoesAPI.Reads.PromocaoModule.Handler
{
    public class ObterPromocaoPorIdHandler : IRequestHandler<ObterPromocaoPorIdQuery, PromocaoDTO>
    {
        private readonly IPromocaoQuery _promocaoQuery;
        public ObterPromocaoPorIdHandler(IPromocaoQuery promocaoQuery)
        {
            _promocaoQuery = promocaoQuery;
        }
        public async Task<PromocaoDTO> Handle(ObterPromocaoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _promocaoQuery.ObterPorIdAsync(request.Id);
        }
    }
}
