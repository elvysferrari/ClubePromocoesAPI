using ClubePromocoesAPI.Commands.PromocaoModule.Command;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Interfaces;
using MediatR;

namespace ClubePromocoesAPI.Commands.PromocaoModule.Handler
{
    public class AdicionarPromocaoCommandHandler : IRequestHandler<AdicionarPromocaoCommand, Promocao>
    {
        private readonly IPromocao _promocao;
        public AdicionarPromocaoCommandHandler(IPromocao promocao)
        {
            _promocao = promocao;
        }
        public async Task<Promocao> Handle(AdicionarPromocaoCommand command, CancellationToken cancellationToken)
        {
            var promocao = new Promocao(command.LojaId, command.UsuarioId, command.CriadaEm, command.DataInicio, command.DataFim, command.Titulo,
                                        command.Descricao, command.Observacao, command.ImagemDestacada, command.ValorDe, command.ValorPor, command.Ativo);


            try
            {
                await _promocao.Adicionar(promocao);
                await _promocao.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return promocao;
        }
    }
}
