using ClubePromocoesAPI.Dapper.Repositories.Base;
using ClubePromocoesAPI.Reads.LojaModule.DTOs;
using ClubePromocoesAPI.Reads.LojaModule.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace ClubePromocoesAPI.Dapper.Repositories
{
    public class LojaQuery : QueryBaseReadonly, ILojaQuery
    {
        public LojaQuery(IConfiguration config) : base(config)
        {

        }
        public async Task<List<LojaDTO>> ObterTodasAsync(int? pageNumber, int? pageSize)
        {
            var sql = $@"SELECT * FROM (
	                        SELECT  
		                        ROW_NUMBER() OVER(ORDER BY loja.id DESC) AS RowNumber,
		                        loja.id Id,
		                        loja.id_categoria CategoriaId,
		                        categoria.nome CategoriaNome,
		                        loja.nome Nome,
		                        loja.descricao Descricao,
		                        loja.criada_em CriadaEm,
		                        loja.imagem Imagem,
		                        loja.abre_as AbreAs,
		                        loja.fecha_as FechaAs,
		                        loja.endereco Endereco,
		                        loja.numero Numero,
		                        loja.bairro Bairro,
		                        loja.cidade Cidade,
		                        loja.uf UF,
		                        loja.fl_ativo Ativo
	                        FROM loja
	                        INNER JOIN categoria ON categoria.id = loja.id_categoria
	                        WHERE loja.fl_ativo = 1
                        ) result	
                        WHERE RowNumber > {pageNumber} AND RowNumber <= ({pageNumber} + {pageSize})";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<LojaDTO>(sql);
                    return result.ToList();
                }
                catch (Exception)
                {
                    connection.Close();
                    return new List<LojaDTO>();
                }
            }
        }
        public async Task<LojaDTO> ObterPorIdAsync(int id)
        {
            var sql = @$"SELECT 		
                            loja.id Id,
		                    loja.id_categoria CategoriaId,
		                    categoria.nome CategoriaNome,
		                    loja.nome Nome,
		                    loja.descricao Descricao,
		                    loja.criada_em CriadaEm,
		                    loja.imagem Imagem,
		                    loja.abre_as AbreAs,
		                    loja.fecha_as FechaAs,
		                    loja.endereco Endereco,
		                    loja.numero Numero,
		                    loja.bairro Bairro,
		                    loja.cidade Cidade,
		                    loja.uf UF,
		                    loja.fl_ativo Ativo
                          FROM loja
                          INNER JOIN categoria ON categoria.id = loja.id_categoria
                          WHERE loja.id = {id}";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    var result = await connection.QueryFirstOrDefaultAsync<LojaDTO>(sql);
                    return result;
                }
                catch (Exception)
                {
                    connection.Close();
                    return new LojaDTO();
                }
            }
        }


    }
}
