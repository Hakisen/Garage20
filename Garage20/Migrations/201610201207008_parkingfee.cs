namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingfee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "TimeOut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Vehicles", "TimeParked", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Vehicles", "ParkingFee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkingFee");
            DropColumn("dbo.Vehicles", "TimeParked");
            DropColumn("dbo.Vehicles", "TimeOut");
        }
    }
}
