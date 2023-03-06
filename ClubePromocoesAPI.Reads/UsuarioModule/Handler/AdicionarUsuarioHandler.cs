using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using ClubePromocoesAPI.Reads.UsuarioModule.Queries;
using ClubePromocoesAPI.Reads.UsuarioModule.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Reads.UsuarioModule.Handler
{
    public class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioQuery, string>
    {
        private readonly IUsuarioQuery _usuarioQuery;
        public AdicionarUsuarioHandler(IUsuarioQuery usuarioQuery)
        {
            _usuarioQuery = usuarioQuery;
        }
        public async Task<string> Handle(AdicionarUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioQuery.Adicionar(request.Nome, request.Email, request.Password, DateTime.Now); ;
        }
    }
}