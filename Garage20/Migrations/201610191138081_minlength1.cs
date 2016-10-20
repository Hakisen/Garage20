namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minlength1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
        }
    }
}
