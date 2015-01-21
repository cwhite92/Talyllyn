namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTicketsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FareId = c.Int(nullable: false),
                        DiscountId = c.Int(),
                        TimetableId = c.Int(nullable: false),
                        Wheelchair = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discounts", t => t.DiscountId)
                .ForeignKey("dbo.Fares", t => t.FareId, cascadeDelete: true)
                .ForeignKey("dbo.Timetables", t => t.TimetableId, cascadeDelete: true)
                .Index(t => t.FareId)
                .Index(t => t.DiscountId)
                .Index(t => t.TimetableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TimetableId", "dbo.Timetables");
            DropForeignKey("dbo.Tickets", "FareId", "dbo.Fares");
            DropForeignKey("dbo.Tickets", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.Tickets", new[] { "TimetableId" });
            DropIndex("dbo.Tickets", new[] { "DiscountId" });
            DropIndex("dbo.Tickets", new[] { "FareId" });
            DropTable("dbo.Tickets");
        }
    }
}
