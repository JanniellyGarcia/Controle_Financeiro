namespace Controle_Financeiro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaGanho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoriaGasto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ganho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Double(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaGanho", t => t.Tipo, cascadeDelete: true)
                .Index(t => t.Tipo);
            
            CreateTable(
                "dbo.Gasto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Double(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaGasto", t => t.Tipo, cascadeDelete: true)
                .Index(t => t.Tipo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "Tipo", "dbo.CategoriaGasto");
            DropForeignKey("dbo.Ganho", "Tipo", "dbo.CategoriaGanho");
            DropIndex("dbo.Gasto", new[] { "Tipo" });
            DropIndex("dbo.Ganho", new[] { "Tipo" });
            DropTable("dbo.Gasto");
            DropTable("dbo.Ganho");
            DropTable("dbo.CategoriaGasto");
            DropTable("dbo.CategoriaGanho");
        }
    }
}
