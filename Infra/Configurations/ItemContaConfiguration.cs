using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;

namespace Infra.Configurations
{
   public class ItemContaConfiguration : EntityTypeConfiguration<ItemConta>
    {
        public ItemContaConfiguration()
        {
            ToTable("Tb_ItemConta");
            HasKey(m => m.IdItem);
            Property(m => m.IdItem).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdItem").IsRequired();

            Property(m => m.IdItem).HasColumnName("IdItem").IsRequired();
            Property(m => m.TpProduto).HasColumnName("TpProduto").IsRequired();
            Property(m => m.QtdItem).HasColumnName("QtdItem").IsRequired();
            Property(m => m.NomeProduto).HasMaxLength(100).HasColumnName("NomeProduto").IsRequired();



            //fk
            DbModelBuilder modelBuilder = new DbModelBuilder();
            modelBuilder.Entity<ItemConta>().
                 HasRequired(c => c.Conta).WithMany().HasForeignKey(c => c.IdConta).WillCascadeOnDelete(false);

        }
    }
}
