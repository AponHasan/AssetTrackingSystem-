namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModelClassModifyall : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssetPurchaseHeader", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetPurchaseHeader", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
