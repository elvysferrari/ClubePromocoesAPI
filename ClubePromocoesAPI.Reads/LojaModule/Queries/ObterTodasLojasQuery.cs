using ClubePromocoesAPI.Reads.LojaModule.DTOs;
using MediatR;

namespace ClubePromocoesAPI.Reads.LojaModule.Queries
{
    public class ObterTodasLojasQuery : IRequest<List<LojaDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public ObterTodasLojasQuery(int? pageNumber, int? pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
