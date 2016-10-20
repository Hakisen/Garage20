namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertynamechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "TimeFee", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "FeeParked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "FeeParked", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "TimeFee");
        }
    }
}
