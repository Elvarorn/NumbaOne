namespace Cloud__.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "ApplicationUserID");
            AddForeignKey("dbo.Projects", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ApplicationUserID" });
            DropColumn("dbo.Projects", "ApplicationUserID");
        }
    }
}
