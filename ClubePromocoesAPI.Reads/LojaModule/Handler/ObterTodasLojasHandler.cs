using ClubePromocoesAPI.Reads.LojaModule.DTOs;
using ClubePromocoesAPI.Reads.LojaModule.Queries;
using ClubePromocoesAPI.Reads.LojaModule.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.LojaModule.Handler
{
    public class ObterTodasLojasHandler : IRequestHandler<ObterTodasLojasQuery, List<LojaDTO>>
    {
        private readonly ILojaQuery _lojaQuery;
        public ObterTodasLojasHandler(ILojaQuery lojaQuery)
        {
            _lojaQuery = lojaQuery;
        }
        public async Task<List<LojaDTO>> Handle(ObterTodasLojasQuery request, CancellationToken cancellationToken)
        {
            return await _lojaQuery.ObterTodasAsync(request.PageNumber, request.PageSize);
        }
    }
}
