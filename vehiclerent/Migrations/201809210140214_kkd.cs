namespace vehiclerent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        TenantEMail = c.String(nullable: false, maxLength: 128),
                        TenantPassword = c.String(nullable: false),
                        TenantName = c.String(nullable: false),
                        TenantNICNo = c.String(nullable: false, maxLength: 10),
                        TenantTpNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TenantEMail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tenants");
        }
    }
}
