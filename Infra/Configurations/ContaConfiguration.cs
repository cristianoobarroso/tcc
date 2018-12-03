using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;

namespace Infra.Configurations
{
  public  class ContaConfiguration : EntityTypeConfiguration<Conta>
    {
        public ContaConfiguration()
        {
            ToTable("Tb_Conta");
            HasKey(m => m.IdConta);
            Property(m => m.IdConta).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdConta").IsRequired();

            Property(m => m.ValorConta).HasColumnName("ValorConta").IsRequired();
            Property(m => m.IdCliente).HasColumnName("IdCliente");
            Property(m => m.DataConta).HasColumnName("DataConta").IsRequired();
            Property(m => m.StatusConta).HasColumnName("StatusConta").IsRequired();
            Property(m => m.NumeroMesa).HasColumnName("NumeroMesa").IsRequired();

            Property(m => m.TpConta).HasColumnName("TpConta").IsRequired();


            //fk
            //DbModelBuilder modelBuilder = new DbModelBuilder();
            //modelBuilder.Entity<Conta>().
            //     HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => c.IdCliente).WillCascadeOnDelete(false);

        }
    }
}
