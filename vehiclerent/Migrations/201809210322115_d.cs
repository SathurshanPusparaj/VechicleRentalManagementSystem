namespace vehiclerent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Renters", "about", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Renters", "about");
        }
    }
}
