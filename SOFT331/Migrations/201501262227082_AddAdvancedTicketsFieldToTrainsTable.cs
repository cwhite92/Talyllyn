namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvancedTicketsFieldToTrainsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trains", "AdvancedTickets", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trains", "AdvancedTickets");
        }
    }
}
