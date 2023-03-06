using ClubePromocoesAPI.Dapper.Repositories.Base;
using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using ClubePromocoesAPI.Reads.UsuarioModule.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using ClubePromocoesAPI.Data.Context;

namespace ClubePromocoesAPI.Dapper.Repositories
{
    public class UsuarioQuery : QueryBaseReadonly, IUsuarioQuery
    {
        private readonly DBContext _context;
        public UsuarioQuery(DBContext context, IConfiguration config) : base(config)
        {
            _context = context;
        }

        public async Task<string> Adicionar(string nome, string email, string password, DateTime criado_em)
        {
            var usuarioExiste = _context.Usuarios.Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (usuarioExiste != null)
                return "Este email já esta sendo usado!";

            var parametros = new DynamicParameters();
            parametros.Add("Nome", nome, DbType.String);
            parametros.Add("Email", email, DbType.String);
            parametros.Add("Password", password, DbType.String);
            parametros.Add("Data", criado_em, DbType.Date);
            parametros.Add("Liberada", true, DbType.Boolean);

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    await connection.ExecuteAsync("Insert into usuario (nome, email, password, criado_em, b_liberada) Values(@Nome, @Email, PWDENCRYPT(@Password), @Data, @Liberada)", parametros);
                    return "success";
                }
                catch (Exception e)
                {
                    connection.Close();
                    return e.Message.ToString();
                }
            }
        }

        public async Task<UsuarioAutenticadoDTO> ObterPorIdAsync(int id)
        {
            var sql = @$"SELECT 
                            id Id,
                            nome Nome,
	                        email Email,
                            b_liberada Liberada
                        FROM usuario
                        WHERE id = {id}";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<UsuarioAutenticadoDTO>(sql);
                    return result;
                }
                catch (Exception)
                {
                    connection.Close();
                    return new UsuarioAutenticadoDTO();
                }
            }
        }

        public async Task<UsuarioAutenticadoDTO> ValidaLogin(string email, string password)
        {
            var sql = @$"SELECT 
                            id Id,
                            nome Nome,
	                        email Email,
                            b_liberada Liberada
                        FROM usuario
                        WHERE email = '{email}' AND PWDCOMPARE('{password}', password) = 1";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<UsuarioAutenticadoDTO>(sql);
                    return result;
                }
                catch (Exception)
                {
                    connection.Close();
                    return new UsuarioAutenticadoDTO();
                }
            }
        }
    }
}
