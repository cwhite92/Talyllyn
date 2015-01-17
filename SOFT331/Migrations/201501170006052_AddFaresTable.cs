namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFaresTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FareGroupId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FareGroups", t => t.FareGroupId, cascadeDelete: true)
                .Index(t => t.FareGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fares", "FareGroupId", "dbo.FareGroups");
            DropIndex("dbo.Fares", new[] { "FareGroupId" });
            DropTable("dbo.Fares");
        }
    }
}
