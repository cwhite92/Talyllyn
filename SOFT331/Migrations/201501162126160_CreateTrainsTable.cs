namespace SOFT331.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrainsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trains",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(nullable: false),
                    Year = c.Int(nullable: false),
                    Capacity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Trains");
        }
    }
}
