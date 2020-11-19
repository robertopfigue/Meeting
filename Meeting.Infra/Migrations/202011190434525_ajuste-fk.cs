namespace Meeting.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustefk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                        InicialDate = c.DateTime(nullable: false),
                        FinalDate = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoomId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email_Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "UserId", "dbo.User");
            DropForeignKey("dbo.Schedule", "RoomId", "dbo.Room");
            DropIndex("dbo.Schedule", new[] { "RoomId" });
            DropIndex("dbo.Schedule", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Schedule");
            DropTable("dbo.Room");
        }
    }
}
