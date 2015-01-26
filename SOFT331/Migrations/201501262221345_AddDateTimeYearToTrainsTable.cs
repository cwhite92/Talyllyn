namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeYearToTrainsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trains", "Year", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trains", "Year");
        }
    }
}
