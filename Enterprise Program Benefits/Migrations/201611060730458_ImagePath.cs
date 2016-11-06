namespace Enterprise_Program_Benefits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.softwares", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.softwares", "ImagePath");
        }
    }
}
