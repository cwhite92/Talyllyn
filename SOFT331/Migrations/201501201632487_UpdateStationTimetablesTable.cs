namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStationTimetablesTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StationTimetables");
            AlterColumn("dbo.StationTimetables", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StationTimetables", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StationTimetables");
            AlterColumn("dbo.StationTimetables", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StationTimetables", new[] { "TimetableId", "StationId" });
        }
    }
}
