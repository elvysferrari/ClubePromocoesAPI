using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubePromocoesAPI.Data.Mapping
{
    public class LojaConfiguration : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("loja");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.CategoriaId).HasColumnName("id_categoria");
            builder.Property(c => c.Nome).HasColumnName("nome");
            builder.Property(c => c.Descricao).HasColumnName("descricao");
            builder.Property(c => c.CriadaEm).HasColumnName("criada_em");
            builder.Property(c => c.Imagem).HasColumnName("imagem");
            builder.Property(c => c.AbreAs).HasColumnName("abre_as");
            builder.Property(c => c.FechaAs).HasColumnName("fecha_as");
            builder.Property(c => c.Endereco).HasColumnName("endereco");
            builder.Property(c => c.Numero).HasColumnName("numero");
            builder.Property(c => c.Bairro).HasColumnName("bairro");
            builder.Property(c => c.Cidade).HasColumnName("cidade");
            builder.Property(c => c.UF).HasColumnName("uf");
            builder.Property(c => c.Ativo).HasColumnName("fl_ativo");
        }
    }
}
