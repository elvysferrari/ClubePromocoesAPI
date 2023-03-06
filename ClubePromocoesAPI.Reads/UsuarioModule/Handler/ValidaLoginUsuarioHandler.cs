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
    public class ValidaLoginUsuarioHandler : IRequestHandler<ValidaLoginUsuarioQuery, UsuarioAutenticadoDTO>
    {
        private readonly IUsuarioQuery _usuarioQuery;
        public ValidaLoginUsuarioHandler(IUsuarioQuery usuarioQuery)
        {
            _usuarioQuery = usuarioQuery;
        }
        public async Task<UsuarioAutenticadoDTO> Handle(ValidaLoginUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioQuery.ValidaLogin(request.Email, request.Password);
        }
    }
}
