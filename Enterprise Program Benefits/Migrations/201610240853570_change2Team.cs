namespace Enterprise_Program_Benefits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2Team : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.resources", "Team", c => c.String());
            DropColumn("dbo.resources", "Company");
        }
        
        public override void Down()
        {
            AddColumn("dbo.resources", "Company", c => c.String());
            DropColumn("dbo.resources", "Team");
        }
    }
}
