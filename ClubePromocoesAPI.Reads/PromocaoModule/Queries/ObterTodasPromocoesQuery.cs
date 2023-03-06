using ClubePromocoesAPI.Reads.PromocaoModule.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.PromocaoModule.Queries
{
    public class ObterTodasPromocoesQuery : IRequest<List<PromocaoDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public ObterTodasPromocoesQuery(int? pageNumber, int? pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
