namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetLocation", "AssetLocationName", c => c.String(nullable: false));
            AlterColumn("dbo.AssetLocation", "ShortName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetLocation", "ShortName", c => c.String());
            AlterColumn("dbo.AssetLocation", "AssetLocationName", c => c.String());
        }
    }
}
