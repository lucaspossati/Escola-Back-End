namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasRelacionadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DatadeNascimento = c.DateTime(),
                        RA = c.Int(nullable: false),
                        Curso = c.String(),
                        Semestre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bibliotecas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        NomeLivro = c.String(),
                        AnoLancamento = c.DateTime(),
                        Genero = c.String(),
                        RA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alunos", t => t.AlunoId, cascadeDelete: true)
                .Index(t => t.AlunoId);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDisciplina = c.String(),
                        NomeProfessor = c.String(),
                        Ementa = c.String(),
                        Curso = c.String(),
                        Periodo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bibliotecas", "AlunoId", "dbo.Alunos");
            DropIndex("dbo.Bibliotecas", new[] { "AlunoId" });
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Bibliotecas");
            DropTable("dbo.Alunos");
        }
    }
}
