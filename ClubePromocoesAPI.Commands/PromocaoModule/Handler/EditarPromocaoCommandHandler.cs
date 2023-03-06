using ClubePromocoesAPI.Commands.LojaModule.Command;
using ClubePromocoesAPI.Commands.PromocaoModule.Command;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Handler
{
    public class EditarPromocaoCommandHandler : IRequestHandler<EditarPromocaoCommand, Promocao>
    {
        private readonly IPromocao _promocao;
        public EditarPromocaoCommandHandler(IPromocao promocao)
        {
            _promocao = promocao;
        }
        public async Task<Promocao> Handle(EditarPromocaoCommand command, CancellationToken cancellationToken)
        {
            var promocao = await _promocao.ObterPorIdAsync(command.Id);
            if (promocao != null)
            {
                promocao.InformarTitulo(command.Titulo)
                    .InformarDescricao(command.Descricao)                    
                    .InformarObservacao(command.Observacao)
                    .InformarDataInicio(command.DataInicio)
                    .InformarDataFim(command.DataFim)
                    .InformarImagemDestacada(command.ImagemDestacada)
                    .InformarValorDe(command.ValorDe)
                    .InformarValorPor(command.ValorPor)
                    .InformarAtivo(command.Ativo);

                await _promocao.Atualizar(promocao);
                await _promocao.SaveChanges();
            }
            else
            {
                //retornar outra coisa depois
            }

            return promocao;
        }
    }
}
