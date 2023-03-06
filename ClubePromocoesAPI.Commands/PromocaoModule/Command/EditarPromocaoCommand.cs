using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Command
{
    public class EditarPromocaoCommand : IRequest<Promocao>
    {
        [JsonIgnore]
        public long Id { get; set; }
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
