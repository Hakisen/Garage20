namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfVehicleId = c.Int(nullable: false),
                        RegNr = c.String(nullable: false, maxLength: 10),
                        colour = c.String(nullable: false, maxLength: 10),
                        Brand = c.String(maxLength: 10),
                        Model = c.String(maxLength: 10),
                        NrOfWheels = c.Int(nullable: false),
                        TimeIn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeOut = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeParked = c.Time(nullable: false, precision: 7),
                        TimeFee = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfVehicles", t => t.TypeOfVehicleId, cascadeDelete: true)
                .Index(t => t.TypeOfVehicleId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "TypeOfVehicleId", "dbo.TypeOfVehicles");
            DropForeignKey("dbo.Vehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.Vehicles", new[] { "MemberId" });
            DropIndex("dbo.Vehicles", new[] { "TypeOfVehicleId" });
            DropTable("dbo.TypeOfVehicles");
            DropTable("dbo.Members");
            DropTable("dbo.Vehicles");
        }
    }
}
