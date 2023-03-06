using ClubePromocoesAPI.Dapper.Repositories.Base;
using ClubePromocoesAPI.Reads.PromocaoModule.DTOs;
using ClubePromocoesAPI.Reads.PromocaoModule.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ClubePromocoesAPI.Dapper.Repositories
{
    public class PromocaoQuery : QueryBaseReadonly, IPromocaoQuery
    {
        public PromocaoQuery(IConfiguration config) : base(config)
        {

        }
        public async Task<List<PromocaoDTO>> ObterTodasAsync(int? pageNumber, int? pageSize)
        {
            var sql = $@"SELECT * FROM (
	                        SELECT 
			                        ROW_NUMBER() OVER(ORDER BY promocao.id DESC) AS RowNumber,
			                        promocao.id Id, 
			                        promocao.id_loja LojaId,
			                        promocao.id_usuario UsuarioId,
			                        promocao.criada_em CriadaEm,
			                        promocao.data_inicio DataInicio,
			                        promocao.data_fim DataFim,
			                        promocao.titulo Titulo,
			                        promocao.descricao Descricao,
			                        promocao.observacao Observacao,
			                        promocao.imagem_destacada ImagemDestacada,
			                        promocao.valor_de ValorDe,
			                        promocao.valor_por ValorPor,
			                        promocao.fl_ativo Ativo,	   
			                        loja.nome LojaNome,
			                        loja.descricao LojaDescricao,	   
			                        usuario.nome UsuarioNome
	                        FROM promocao
	                        INNER JOIN loja on loja.id = promocao.id_loja
	                        INNER JOIN usuario on usuario.id = promocao.id_usuario
	                        WHERE promocao.fl_ativo = 1 and getdate() between promocao.data_inicio and promocao.data_fim
                        ) result
                        WHERE RowNumber > {pageNumber} AND RowNumber <= ({pageNumber} + {pageSize})";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<PromocaoDTO>(sql);
                    return result.ToList();
                }
                catch (Exception)
                {
                    connection.Close();
                    return new List<PromocaoDTO>();
                }
            }
        }
        public async Task<PromocaoDTO> ObterPorIdAsync(int id)
        {
            var sql = @$"SELECT promocao.id Id, 
	                           promocao.id_loja LojaId,
	                           promocao.id_usuario UsuarioId,
	                           promocao.criada_em CriadaEm,
	                           promocao.data_inicio DataInicio,
	                           promocao.data_fim DataFim,
	                           promocao.titulo Titulo,
	                           promocao.descricao Descricao,
	                           promocao.observacao Observacao,
	                           promocao.imagem_destacada ImagemDestacada,
	                           promocao.valor_de ValorDe,
	                           promocao.valor_por ValorPor,
	                           promocao.fl_ativo Ativo,	   
	                           loja.nome LojaNome,
	                           loja.descricao LojaDescricao,	   
	                           usuario.nome UsuarioNome
                          FROM promocao
                          INNER JOIN loja on loja.id = promocao.id_loja
                          INNER JOIN usuario on usuario.id = promocao.id_usuario
                          WHERE promocao.id = {id}";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryFirstOrDefaultAsync<PromocaoDTO>(sql);
                    return result;
                }
                catch (Exception)
                {
                    connection.Close();
                    return new PromocaoDTO();
                }
            }
        }


    }
}
