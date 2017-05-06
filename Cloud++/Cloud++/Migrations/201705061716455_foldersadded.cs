namespace Cloud__.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foldersadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        folderName = c.String(),
                        projectID = c.Int(nullable: false),
                        parentFolderID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Folders");
        }
    }
}
