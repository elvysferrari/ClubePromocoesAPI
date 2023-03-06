using Microsoft.EntityFrameworkCore;
using ClubePromocoesAPI.Data.Context;
using ClubePromocoesAPI.Data.Repository.Base;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Interfaces;

namespace ClubePromocoesAPI.Data.Repository
{
    public class LojaRepository : Repository<Loja>, ILoja
    {
        private readonly DBContext _context;
        public LojaRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Loja> ObterPorIdAsync(long id)
        {
            return await _context.Lojas.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
