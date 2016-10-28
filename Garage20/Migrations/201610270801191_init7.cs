namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "MemberName", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "colour", c => c.String(maxLength: 10));
            AlterColumn("dbo.TypeOfVehicles", "VehicleType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeOfVehicles", "VehicleType", c => c.String());
            AlterColumn("dbo.Vehicles", "colour", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Members", "MemberName", c => c.String());
        }
    }
}
