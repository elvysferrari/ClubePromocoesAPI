using ClubePromocoesAPI.Reads.LojaModule.DTOs;
using MediatR;

namespace ClubePromocoesAPI.Reads.LojaModule.Queries
{
    public class ObterLojaPorIdQuery : IRequest<LojaDTO>
    {
        public int Id { get; set; }        
        public ObterLojaPorIdQuery(int id)
        {
            Id = id;            
        }
    }
}
