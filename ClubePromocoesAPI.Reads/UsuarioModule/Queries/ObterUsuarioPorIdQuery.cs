using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.UsuarioModule.Queries
{
    public class ObterUsuarioPorIdQuery : IRequest<UsuarioAutenticadoDTO>
    {
        public int Id { get; set; }
        public ObterUsuarioPorIdQuery(int id)
        {
            Id = id;
        }
    }
}
