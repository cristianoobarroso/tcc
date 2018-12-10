namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_Buffet",
                c => new
                    {
                        IdBuffet = c.Int(nullable: false, identity: true),
                        TipoBuffet = c.String(nullable: false, maxLength: 100),
                        NomeBuffet = c.String(nullable: false, maxLength: 100),
                        TpProduto = c.Int(nullable: false),
                        NacionalidadeBuffet = c.String(nullable: false, maxLength: 100),
                        ValorBuffet = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdBuffet);
            
            CreateTable(
                "dbo.Tb_Cerveja",
                c => new
                    {
                        IdCerveja = c.Int(nullable: false, identity: true),
                        NomeCerveja = c.String(nullable: false, maxLength: 100),
                        ValorCerveja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QTDCervejaEstoque = c.Int(nullable: false),
                        NacionalidadeCerveja = c.String(nullable: false, maxLength: 100),
                        TpProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCerveja);
            
            CreateTable(
                "dbo.Tb_Cliente",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 100),
                        CPFCliente = c.String(nullable: false, maxLength: 100),
                        EmailCliente = c.String(nullable: false, maxLength: 100),
                        TpCliente = c.Int(nullable: false),
                        DtaCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Tb_Conta",
                c => new
                    {
                        IdConta = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        ValorConta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataConta = c.DateTime(nullable: false),
                        StatusConta = c.Boolean(nullable: false),
                        NumeroMesa = c.Int(nullable: false),
                        TpConta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdConta);
            
            CreateTable(
                "dbo.Tb_Funcionario",
                c => new
                    {
                        IdFuncionario = c.Int(nullable: false, identity: true),
                        Perfil = c.Int(nullable: false),
                        NomeFuncionario = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdFuncionario);
            
            CreateTable(
                "dbo.Tb_ItemConta",
                c => new
                    {
                        IdItem = c.Int(nullable: false, identity: true),
                        IdConta = c.Int(nullable: false),
                        TpProduto = c.Int(nullable: false),
                        QtdItem = c.Int(nullable: false),
                        NomeProduto = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdItem)
                .ForeignKey("dbo.Tb_Conta", t => t.IdConta, cascadeDelete: true)
                .Index(t => t.IdConta);
            
            CreateTable(
                "dbo.Tb_Prato",
                c => new
                    {
                        IdPrato = c.Int(nullable: false, identity: true),
                        NomePrato = c.String(nullable: false, maxLength: 100),
                        TpProduto = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdPrato);
            
            CreateTable(
                "dbo.Tb_Queijo",
                c => new
                    {
                        IdQueijo = c.Int(nullable: false, identity: true),
                        DataVenda = c.String(nullable: false),
                        NomeProduto = c.String(nullable: false, maxLength: 100),
                        TpProduto = c.Int(nullable: false),
                        QTDQueijoEstoque = c.Int(nullable: false),
                        Nacionalidade = c.String(nullable: false, maxLength: 100),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdQueijo);
            
            CreateTable(
                "dbo.Tb_Vendas",
                c => new
                    {
                        IdVenda = c.Int(nullable: false, identity: true),
                        TpProduto = c.Int(nullable: false),
                        QtdVendido = c.Int(nullable: false),
                        NomeProduto = c.String(nullable: false, maxLength: 100),
                        DataVenda = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenda);
            
            CreateTable(
                "dbo.Tb_Vinho",
                c => new
                    {
                        IdVinho = c.Int(nullable: false, identity: true),
                        TipoVinho = c.String(nullable: false, maxLength: 100),
                        NomeVinho = c.String(nullable: false, maxLength: 100),
                        TpProduto = c.Int(nullable: false),
                        QTDVinhoEstoque = c.Int(nullable: false),
                        Nacionalidade = c.String(nullable: false),
                        ValorVinho = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdVinho);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_ItemConta", "IdConta", "dbo.Tb_Conta");
            DropIndex("dbo.Tb_ItemConta", new[] { "IdConta" });
            DropTable("dbo.Tb_Vinho");
            DropTable("dbo.Tb_Vendas");
            DropTable("dbo.Tb_Queijo");
            DropTable("dbo.Tb_Prato");
            DropTable("dbo.Tb_ItemConta");
            DropTable("dbo.Tb_Funcionario");
            DropTable("dbo.Tb_Conta");
            DropTable("dbo.Tb_Cliente");
            DropTable("dbo.Tb_Cerveja");
            DropTable("dbo.Tb_Buffet");
        }
    }
}
