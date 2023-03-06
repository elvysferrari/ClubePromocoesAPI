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
    public class EditarLojaCommandHandler : IRequestHandler<EditarLojaCommand, Loja>
    {
        private readonly ILoja _loja;
        public EditarLojaCommandHandler(ILoja loja)
        {
            _loja = loja;
        }
        public async Task<Loja> Handle(EditarLojaCommand command, CancellationToken cancellationToken)
        {
            var loja = await _loja.ObterPorIdAsync(command.Id);
            if(loja != null) 
            {
                loja.InformarCategoria(command.CategoriaId)
                    .InformarNome(command.Nome)
                    .InformarDescricao(command.Descricao)
                    .InformarImagem(command.Imagem)
                    .InformarAbreAs(command.AbreAs)
                    .InformarFechaAs(command.FechaAs)
                    .InformarEndereco(command.Endereco)
                    .InformarNumero(command.Numero)
                    .InformarBairro(command.Bairro)
                    .InformarCidade(command.Cidade)
                    .InformarUF(command.UF)
                    .InformarAtivo(command.Ativo);

                await _loja.Atualizar(loja);
                await _loja.SaveChanges();
            }
            else
            {
                //retornar outra coisa depois
            }
            
            return loja;
        }
    }
}
