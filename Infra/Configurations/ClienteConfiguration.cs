using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;
namespace Infra.Configurations
{
  public  class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Tb_Cliente");
            HasKey(m => m.IdCliente);
            Property(m => m.IdCliente).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdCliente").IsRequired();

            Property(m => m.NomeCliente).HasMaxLength(100).HasColumnName("NomeCliente").IsRequired();
            Property(m => m.CPFCliente).HasMaxLength(100).HasColumnName("CPFCliente").IsRequired();
            Property(m => m.EmailCliente).HasMaxLength(100).HasColumnName("EmailCliente").IsRequired();
            Property(m => m.DtaCadastro).HasColumnName("DtaCadastro").IsRequired();
            Property(m => m.TpCliente).HasColumnName("TpCliente");
        }
    }
}
