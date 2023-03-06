using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using ClubePromocoesAPI.Data.Repository.Base;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Data.Context;
using ClubePromocoesAPI.Domain.Interfaces;

namespace ClubePromocoesAPI.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuario
    {
        private readonly DBContext _context;        

        public UsuarioRepository(DBContext context) : base(context)
        {
            _context = context;            
        }
        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
