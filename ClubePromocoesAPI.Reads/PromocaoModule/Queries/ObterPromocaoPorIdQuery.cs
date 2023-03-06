using ClubePromocoesAPI.Reads.PromocaoModule.DTOs;
using MediatR;

namespace ClubePromocoesAPI.Reads.PromocaoModule.Queries
{
    public class ObterPromocaoPorIdQuery : IRequest<PromocaoDTO>
    {
        public int Id { get; set; }        
        public ObterPromocaoPorIdQuery(int id)
        {
            Id = id;            
        }
    }
}
