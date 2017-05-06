namespace Cloud__.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        folderID = c.Int(nullable: false),
                        fileName = c.String(),
                        content = c.String(),
                        extension = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Files");
        }
    }
}
