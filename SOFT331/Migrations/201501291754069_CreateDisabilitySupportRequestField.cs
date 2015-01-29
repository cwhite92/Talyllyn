namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDisabilitySupportRequestField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "DisabilitySupportRequest", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "DisabilitySupportRequest");
        }
    }
}
