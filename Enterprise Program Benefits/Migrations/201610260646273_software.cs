namespace Enterprise_Program_Benefits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class software : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.softwares",
                c => new
                    {
                        SoftwareId = c.Int(nullable: false, identity: true),
                        SoftwareName = c.String(),
                        Description = c.String(),
                        TokenRate = c.String(),
                        LearnIt = c.String(),
                        ProductFamily = c.String(),
                        Platform = c.String(),
                        LicenseType = c.String(),
                    })
                .PrimaryKey(t => t.SoftwareId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.softwares");
        }
    }
}
