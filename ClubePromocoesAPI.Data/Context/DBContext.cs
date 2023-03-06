using ClubePromocoesAPI.Domain.Base;
using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ClubePromocoesAPI.Data.Context
{
    public partial class DBContext : DbContext, IDBContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
     
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Promocao> Promocoes { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PromocaoConfiguration());
            modelBuilder.ApplyConfiguration(new LojaConfiguration());
        }
       
    }
}
