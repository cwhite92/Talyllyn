namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OhGodWhatHappened : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Timetables", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Timetables", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
