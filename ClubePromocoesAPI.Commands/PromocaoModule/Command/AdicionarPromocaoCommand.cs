using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Enums;
using MediatR;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Command
{
    public class AdicionarPromocaoCommand : IRequest<Promocao>
    {
        public long LojaId { get; set; }        
        public long UsuarioId { get; set; }        
        public DateTime CriadaEm { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string ImagemDestacada { get; set; }
        public decimal? ValorDe { get; set; }
        public decimal? ValorPor { get; set; }
        public bool Ativo { get; set; }
    }
}
