namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetArrivalDepartureToOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StationTimetables", "Arrival", c => c.Time(precision: 7));
            AlterColumn("dbo.StationTimetables", "Departure", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StationTimetables", "Departure", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.StationTimetables", "Arrival", c => c.Time(nullable: false, precision: 7));
        }
    }
}
