namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alunos", "Login", c => c.String());
            AddColumn("dbo.Alunos", "Senha", c => c.String());
            DropColumn("dbo.Alunos", "Teste");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alunos", "Teste", c => c.String());
            DropColumn("dbo.Alunos", "Senha");
            DropColumn("dbo.Alunos", "Login");
        }
    }
}
