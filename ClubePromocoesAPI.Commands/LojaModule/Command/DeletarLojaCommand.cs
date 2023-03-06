using ClubePromocoesAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.LojaModule.Command
{
    public class DeletarLojaCommand : IRequest<bool>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public DeletarLojaCommand(long id)
        {
            Id = id;
        }
    }
}
