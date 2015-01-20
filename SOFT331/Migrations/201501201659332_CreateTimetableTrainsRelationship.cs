namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTimetableTrainsRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timetables", "TrainId", c => c.Int(nullable: false));
            CreateIndex("dbo.Timetables", "TrainId");
            AddForeignKey("dbo.Timetables", "TrainId", "dbo.Trains", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timetables", "TrainId", "dbo.Trains");
            DropIndex("dbo.Timetables", new[] { "TrainId" });
            DropColumn("dbo.Timetables", "TrainId");
        }
    }
}
