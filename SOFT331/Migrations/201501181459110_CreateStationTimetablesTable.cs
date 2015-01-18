namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStationTimetablesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StationTimetables",
                c => new
                    {
                        StationId = c.Int(nullable: false),
                        TimetableId = c.Int(nullable: false),
                        Arrival = c.Time(nullable: false, precision: 7),
                        Departure = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.StationId, t.TimetableId })
                .ForeignKey("dbo.Stations", t => t.StationId, cascadeDelete: true)
                .ForeignKey("dbo.Timetables", t => t.TimetableId, cascadeDelete: true)
                .Index(t => t.StationId)
                .Index(t => t.TimetableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StationTimetables", "TimetableId", "dbo.Timetables");
            DropForeignKey("dbo.StationTimetables", "StationId", "dbo.Stations");
            DropIndex("dbo.StationTimetables", new[] { "TimetableId" });
            DropIndex("dbo.StationTimetables", new[] { "StationId" });
            DropTable("dbo.StationTimetables");
        }
    }
}
