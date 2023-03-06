using ClubePromocoesAPI.Reads.PromocaoModule.DTOs;
using ClubePromocoesAPI.Reads.PromocaoModule.Queries;
using ClubePromocoesAPI.Reads.PromocaoModule.Repositories;
using MediatR;

namespace ClubePromocoesAPI.Reads.PromocaoModule.Handler
{
    public class ObterTodasLojasHandler : IRequestHandler<ObterTodasPromocoesQuery, List<PromocaoDTO>>
    {
        private readonly IPromocaoQuery _promocaoQuery;
        public ObterTodasLojasHandler(IPromocaoQuery promocaoQuery)
        {
            _promocaoQuery = promocaoQuery;
        }
        public async Task<List<PromocaoDTO>> Handle(ObterTodasPromocoesQuery request, CancellationToken cancellationToken)
        {
            return await _promocaoQuery.ObterTodasAsync(request.PageNumber, request.PageSize);
        }
    }
}
