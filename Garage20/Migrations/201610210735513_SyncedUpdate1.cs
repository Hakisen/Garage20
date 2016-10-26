namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncedUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "TimeOut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Vehicles", "TimeParked", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Vehicles", "TimeFee", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Vehicles", "colour", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Vehicles", "Brand", c => c.String(maxLength: 10));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Brand", c => c.String());
            AlterColumn("dbo.Vehicles", "colour", c => c.String());
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
            DropColumn("dbo.Vehicles", "TimeFee");
            DropColumn("dbo.Vehicles", "TimeParked");
            DropColumn("dbo.Vehicles", "TimeOut");
        }
    }
}
