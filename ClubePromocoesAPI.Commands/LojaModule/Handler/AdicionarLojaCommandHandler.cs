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

namespace ClubePromocoesAPI.Commands.LojaModule.Handler
{
    public class AdicionarLojaCommandHandler : IRequestHandler<AdicionarLojaCommand, Loja>
    {
        private readonly ILoja _loja;
        public AdicionarLojaCommandHandler(ILoja loja)
        {
            _loja = loja;
        }
        public async Task<Loja> Handle(AdicionarLojaCommand command, CancellationToken cancellationToken)
        {
            var loja = new Loja(command.CategoriaId, command.Nome, command.Descricao, command.CriadaEm, command.Imagem, command.AbreAs, command.FechaAs,
                                command.Endereco, command.Numero, command.Bairro, command.Cidade, command.UF, command.Ativo);

            try
            {
                await _loja.Adicionar(loja);
                await _loja.SaveChanges();
            }catch(Exception ex)
            {

            }

            return loja;
        }
    }
}
