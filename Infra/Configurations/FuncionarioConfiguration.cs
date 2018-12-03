using System.Data.Entity.ModelConfiguration;
using Domain.Entity;
using System.Data.Entity;
namespace Infra.Configurations
{
  public  class FuncionarioConfiguration : EntityTypeConfiguration<Fucionario>
    {
        public FuncionarioConfiguration()
        {
            ToTable("Tb_Funcionario");
            HasKey(m => m.IdFuncionario);
            Property(m => m.IdFuncionario).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdFuncionario").IsRequired();

            Property(m => m.Perfil).HasColumnName("Perfil").IsRequired();
            Property(m => m.NomeFuncionario).HasMaxLength(100).HasColumnName("NomeFuncionario").IsRequired();
            Property(m => m.Login).HasMaxLength(100).HasColumnName("Login").IsRequired();
            Property(m => m.Senha).HasMaxLength(100).HasColumnName("Senha").IsRequired();

        }
    }
}
