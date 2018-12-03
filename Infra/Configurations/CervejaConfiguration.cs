using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;


namespace Infra.Configurations
{
   public class CervejaConfiguration : EntityTypeConfiguration<Cerveja>
    {
        public CervejaConfiguration()
        {
            ToTable("Tb_Cerveja");
            HasKey(m => m.IdCerveja);
            Property(m => m.IdCerveja).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdCerveja").IsRequired();

            Property(m => m.NomeCerveja).HasMaxLength(100).HasColumnName("NomeCerveja").IsRequired();
            Property(m => m.ValorCerveja).HasColumnName("ValorCerveja").IsRequired();
            Property(m => m.QTDCervejaEstoque).HasColumnName("QTDCervejaEstoque").IsRequired();
            Property(m => m.NacionalidadeCerveja).HasMaxLength(100).HasColumnName("NacionalidadeCerveja").IsRequired();
            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
        }
    }
}
