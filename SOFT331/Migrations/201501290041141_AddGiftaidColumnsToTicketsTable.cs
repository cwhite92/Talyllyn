namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGiftaidColumnsToTicketsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "GiftaidName", c => c.String(maxLength: 50));
            AddColumn("dbo.Tickets", "GiftaidAddressFirstLine", c => c.String(maxLength: 50));
            AddColumn("dbo.Tickets", "GiftaidPostcode", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "GiftaidPostcode");
            DropColumn("dbo.Tickets", "GiftaidAddressFirstLine");
            DropColumn("dbo.Tickets", "GiftaidName");
        }
    }
}
