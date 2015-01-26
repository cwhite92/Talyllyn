namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveYearColumnFromTrainsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trains", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trains", "Year", c => c.Int(nullable: false));
        }
    }
}
