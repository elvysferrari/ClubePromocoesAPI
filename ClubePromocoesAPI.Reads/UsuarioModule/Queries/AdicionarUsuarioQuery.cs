using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.UsuarioModule.Queries
{
    public class AdicionarUsuarioQuery : IRequest<string>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AdicionarUsuarioQuery(string nome, string email, string password)
        {
            Nome = nome;
            Email = email;
            Password = password;
        }
    }
}
