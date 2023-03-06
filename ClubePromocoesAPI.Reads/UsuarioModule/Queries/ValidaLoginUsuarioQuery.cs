using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.UsuarioModule.Queries
{
    public class ValidaLoginUsuarioQuery : IRequest<UsuarioAutenticadoDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ValidaLoginUsuarioQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
