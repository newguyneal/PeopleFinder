namespace ThePeopleSearchApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
