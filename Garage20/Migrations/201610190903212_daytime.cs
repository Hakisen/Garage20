namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daytime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
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
        }
    }
}
