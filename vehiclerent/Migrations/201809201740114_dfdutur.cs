namespace vehiclerent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfdutur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        RenterEMail = c.String(nullable: false, maxLength: 128),
                        RenterName = c.String(nullable: false),
                        RenterNICNo = c.String(nullable: false, maxLength: 10),
                        RenterTpNo = c.String(nullable: false),
                        RenterPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RenterEMail);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.String(nullable: false, maxLength: 128),
                        VehicleType = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        Image = c.String(),
                        price = c.Single(nullable: false),
                        capacity = c.Int(nullable: false),
                        doors = c.Int(nullable: false),
                        air = c.String(nullable: false),
                        transmission = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        RenterEMail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Renters", t => t.RenterEMail)
                .Index(t => t.RenterEMail);
            
            CreateTable(
                "dbo.VehicleAvailabilities",
                c => new
                    {
                        AvailabilityId = c.Int(nullable: false, identity: true),
                        VehicleId = c.String(),
                        VehicleAvailableFrom = c.String(),
                        VehicleAvailableTo = c.String(),
                        VehicleLocation = c.String(),
                        latitude = c.Single(nullable: false),
                        longitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AvailabilityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "RenterEMail", "dbo.Renters");
            DropIndex("dbo.Vehicles", new[] { "RenterEMail" });
            DropTable("dbo.VehicleAvailabilities");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Renters");
        }
    }
}
