namespace Enterprise_Program_Benefits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changearray : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.resources", "reponsibilities", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.resources", "reponsibilities");
        }
    }
}
