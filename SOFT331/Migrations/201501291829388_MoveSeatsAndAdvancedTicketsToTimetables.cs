namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveSeatsAndAdvancedTicketsToTimetables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timetables", "Seats", c => c.Int(nullable: false));
            AddColumn("dbo.Timetables", "AdvancedTickets", c => c.Int(nullable: false));
            DropColumn("dbo.Trains", "Capacity");
            DropColumn("dbo.Trains", "AdvancedTickets");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trains", "AdvancedTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Trains", "Capacity", c => c.Int(nullable: false));
            DropColumn("dbo.Timetables", "AdvancedTickets");
            DropColumn("dbo.Timetables", "Seats");
        }
    }
}
