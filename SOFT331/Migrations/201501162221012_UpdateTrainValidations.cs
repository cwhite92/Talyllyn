namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrainValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trains", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Trains", "Description", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trains", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Trains", "Name", c => c.String(nullable: false));
        }
    }
}
