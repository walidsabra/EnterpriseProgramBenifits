namespace Enterprise_Program_Benefits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.resources", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.resources", "Company");
        }
    }
}
