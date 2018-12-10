using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;
namespace Infra.Configurations
{
  public  class VinhoConfiguration : EntityTypeConfiguration<Vinho>
    {
        public VinhoConfiguration()
        {

            ToTable("Tb_Vinho");
            HasKey(m => m.IdVinho);
            Property(m => m.IdVinho).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdVinho").IsRequired();

            Property(m => m.TipoVinho).HasMaxLength(100).HasColumnName("TipoVinho").IsRequired();
            Property(m => m.NomeVinho).HasMaxLength(100).HasColumnName("NomeVinho").IsRequired();
            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
            Property(m => m.QTDVinhoEstoque).HasColumnName("QTDVinhoEstoque").IsRequired();
            Property(m => m.Nacionalidade).HasColumnName("Nacionalidade").IsRequired();
            Property(m => m.ValorVinho).HasColumnName("ValorVinho").IsRequired();

        }
    }
}
