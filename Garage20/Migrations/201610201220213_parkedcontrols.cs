namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkedcontrols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "FeeParked", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "ParkingFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ParkingFee", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "FeeParked");
        }
    }
}
