using Microsoft.EntityFrameworkCore;
using ClubePromocoesAPI.Data.Context;
using ClubePromocoesAPI.Data.Repository.Base;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Interfaces;

namespace ClubePromocoesAPI.Data.Repository
{
    public class PromocaoRepository : Repository<Promocao>, IPromocao
    {
        private readonly DBContext _context;
        public PromocaoRepository(DBContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Promocao> ObterPorIdAsync(long id)
        {
            return await _context.Promocoes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
