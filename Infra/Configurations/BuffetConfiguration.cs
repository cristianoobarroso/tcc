using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;

namespace Infra.Configurations
{
 public   class BuffetConfiguration : EntityTypeConfiguration<Buffet>
    {
        public BuffetConfiguration()
        {
            ToTable("Tb_Buffet");
            HasKey(m => m.IdBuffet);
            Property(m => m.IdBuffet).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdBuffet").IsRequired();

            Property(m => m.TipoBuffet).HasMaxLength(100).HasColumnName("TipoBuffet").IsRequired();
            Property(m => m.NomeBuffet).HasMaxLength(100).HasColumnName("NomeBuffet").IsRequired();
            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
            Property(m => m.NacionalidadeBuffet).HasMaxLength(100).HasColumnName("NacionalidadeBuffet").IsRequired();
            Property(m => m.ValorBuffet).HasColumnName("ValorBuffet").IsRequired();

        }
    }
}
