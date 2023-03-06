using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.LojaModule.Command
{
    public class EditarLojaCommand : IRequest<Loja>
    {
        [JsonIgnore]
        public long Id { get; set; } 
        public long CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }        
        public string Imagem { get; set; }
        public DateTime? AbreAs { get; set; }
        public DateTime? FechaAs { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }
    }
}
