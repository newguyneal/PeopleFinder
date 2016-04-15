namespace ThePeopleSearchApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationuid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        uid = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        address = c.String(),
                        age = c.Int(nullable: false),
                        interests = c.String(),
                    })
                .PrimaryKey(t => t.uid);
            
            DropTable("dbo.People");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        first_name = c.String(nullable: false, maxLength: 128),
                        last_name = c.String(),
                        address = c.String(),
                        age = c.String(),
                        interests = c.String(),
                    })
                .PrimaryKey(t => t.first_name);
            
            DropTable("dbo.Entities");
        }
    }
}
