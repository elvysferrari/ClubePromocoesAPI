using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubePromocoesAPI.Domain.Base;
using ClubePromocoesAPI.Domain.Enums;

namespace ClubePromocoesAPI.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; private set; }    
        public Ativo Ativo { get; private set; }
    }
}
