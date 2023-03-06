using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Command
{
    public class DeletarPromocaoCommand : IRequest<bool>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public DeletarPromocaoCommand(int id)
        {
            Id = id;
        }
    }
}
