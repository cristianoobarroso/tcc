using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;
namespace Infra.Configurations
{
   public  class QueijoConfiguration : EntityTypeConfiguration<Queijo>
    {
        public QueijoConfiguration()
        {
            ToTable("Tb_Queijo");
            HasKey(m => m.IdQueijo );
            Property(m => m.IdQueijo).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdQueijo").IsRequired();

            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
            Property(m => m.NomeQueijo).HasMaxLength(100).HasColumnName("NomeProduto").IsRequired();
            Property(m => m.TipoQueijo).HasColumnName("DataVenda").IsRequired();
            Property(m => m.QTDQueijoEstoque).HasColumnName("QTDQueijoEstoque").IsRequired();

        }
    }
}
