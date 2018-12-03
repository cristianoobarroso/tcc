using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;

namespace Infra.Configurations
{
  public  class VendasConfiguration : EntityTypeConfiguration<Vendas>
    {
        public VendasConfiguration()
        {
            ToTable("Tb_Vendas");
            HasKey(m => m.IdVenda);
            Property(m => m.IdVenda).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdVenda").IsRequired();

            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
            Property(m => m.NomeProduto).HasMaxLength(100).HasColumnName("NomeProduto").IsRequired();
            Property(m => m.DataVenda).HasColumnName("DataVenda").IsRequired();
        }
    }
}
