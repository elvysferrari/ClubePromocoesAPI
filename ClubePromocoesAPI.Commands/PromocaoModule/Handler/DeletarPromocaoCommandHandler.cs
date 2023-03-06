using ClubePromocoesAPI.Commands.LojaModule.Command;
using ClubePromocoesAPI.Commands.PromocaoModule.Command;
using ClubePromocoesAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Handler
{
    public class DeletarPromocaoCommandHandler : IRequestHandler<DeletarPromocaoCommand, bool>
    {
        private readonly IPromocao _promocao;
        public DeletarPromocaoCommandHandler(IPromocao promocao)
        {
            _promocao = promocao;
        }
        public async Task<bool> Handle(DeletarPromocaoCommand command, CancellationToken cancellationToken)
        {
            var promocao = await _promocao.ObterPorIdAsync(command.Id);
            if (promocao != null)
            {
                await _promocao.Remover(promocao);
                await _promocao.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
