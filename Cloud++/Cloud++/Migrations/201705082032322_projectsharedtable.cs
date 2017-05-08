namespace Cloud__.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectsharedtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectShared",
                c => new
                    {
                        ProjectID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjectID, t.UserID })
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectShared", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectShared", "ProjectID", "dbo.Projects");
            DropIndex("dbo.ProjectShared", new[] { "UserID" });
            DropIndex("dbo.ProjectShared", new[] { "ProjectID" });
            DropTable("dbo.ProjectShared");
        }
    }
}
