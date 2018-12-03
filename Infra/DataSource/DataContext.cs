using System.Configuration;
using Domain.Entity;
using System.Data.Entity;
using Infra.Configurations;


namespace Infra.DataSource
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["BuffeCris"].ConnectionString)
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BuffetConfiguration());
            modelBuilder.Configurations.Add(new CervejaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ContaConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new ItemContaConfiguration());
            modelBuilder.Configurations.Add(new MassaConfiguration());
            modelBuilder.Configurations.Add(new QueijoConfiguration());
            modelBuilder.Configurations.Add(new VendasConfiguration());
            modelBuilder.Configurations.Add(new VinhoConfiguration());
        }

        public DbSet<Buffet> Buffet { get; set; }
        public DbSet<Cerveja> Cerveja { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Fucionario> Fucionario { get; set; }
        public DbSet<ItemConta> ItemConta { get; set; }
        public DbSet<Massa> Massa { get; set; }
        public DbSet<Queijo> Queijo { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Vinho> Vinho { get; set; }

    }
}
