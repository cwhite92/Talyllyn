namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEventsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Trains", "EventId", c => c.Int());
            CreateIndex("dbo.Trains", "EventId");
            AddForeignKey("dbo.Trains", "EventId", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trains", "EventId", "dbo.Events");
            DropIndex("dbo.Trains", new[] { "EventId" });
            DropColumn("dbo.Trains", "EventId");
            DropTable("dbo.Events");
        }
    }
}
