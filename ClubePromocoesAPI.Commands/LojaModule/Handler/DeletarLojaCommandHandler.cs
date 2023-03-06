using ClubePromocoesAPI.Commands.LojaModule.Command;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.LojaModule.Handler
{
    public class DeletarLojaCommandHandler : IRequestHandler<DeletarLojaCommand, bool>
    {
        private readonly ILoja _loja;
        public DeletarLojaCommandHandler(ILoja loja)
        {
            _loja = loja;
        }
        public async Task<bool> Handle(DeletarLojaCommand command, CancellationToken cancellationToken)
        {
            var loja = await _loja.ObterPorIdAsync(command.Id);
            if (loja != null)
            {               
                await _loja.Remover(loja);
                await _loja.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }           
        }
    }
}
