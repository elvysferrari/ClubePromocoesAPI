using ClubePromocoesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubePromocoesAPI.Data.Mapping
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(200);
            builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(200);
            builder.Property(c => c.Password).HasColumnName("password").HasMaxLength(50);
            builder.Property(c => c.CriadoEm).HasColumnName("criado_em");
            builder.Property(c => c.Liberada).HasColumnName("b_liberada");
        }
    }
}
