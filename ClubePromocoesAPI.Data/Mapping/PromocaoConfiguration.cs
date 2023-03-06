using ClubePromocoesAPI.Domain.Entities;
using ClubePromocoesAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubePromocoesAPI.Data.Mapping
{
    public class PromocaoConfiguration : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("promocao");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.LojaId).HasColumnName("id_loja");
            builder.Property(c => c.UsuarioId).HasColumnName("id_usuario");
            builder.Property(c => c.CriadaEm).HasColumnName("criada_em");
            builder.Property(c => c.DataInicio).HasColumnName("data_inicio");
            builder.Property(c => c.DataFim).HasColumnName("data_fim");
            builder.Property(c => c.Titulo).HasColumnName("titulo");
            builder.Property(c => c.Descricao).HasColumnName("descricao");
            builder.Property(c => c.Observacao).HasColumnName("observacao");
            builder.Property(c => c.ImagemDestacada).HasColumnName("imagem_destacada");
            builder.Property(c => c.ValorDe).HasColumnName("valor_de");
            builder.Property(c => c.ValorPor).HasColumnName("valor_por");
            builder.Property(c => c.Ativo).HasColumnName("fl_ativo");
        }
    }
}
