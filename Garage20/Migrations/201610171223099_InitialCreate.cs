namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfVehicle = c.Int(nullable: false),
                        RegNr = c.String(),
                        colour = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        NrOfWheels = c.Int(nullable: false),
                        TimeIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
