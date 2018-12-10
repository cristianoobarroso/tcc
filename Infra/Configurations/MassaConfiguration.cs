using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;

namespace Infra.Configurations
{
  public  class MassaConfiguration : EntityTypeConfiguration<Massa>
    {
        public MassaConfiguration()
        {
            ToTable("Tb_Prato");
            HasKey(m => m.IdMassa);
            Property(m => m.IdMassa).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdPrato").IsRequired();

            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
            Property(m => m.NomeMassa).HasMaxLength(100).HasColumnName("NomePrato").IsRequired();
           // Property(m => m.TipoMassa).HasColumnName("TipoPrato").IsRequired();
            Property(m => m.Valor).HasColumnName("Valor").IsRequired();
            // Property(m => m.QTDEMassaEstoque).HasColumnName("QTDEMassaEstoque").IsRequired();
        }
    }
}
