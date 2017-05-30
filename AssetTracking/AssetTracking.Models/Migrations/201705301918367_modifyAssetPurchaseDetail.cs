namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAssetPurchaseDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetPurchaseDetail", "CategoryID", "dbo.Category");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "CategoryID" });
            AddColumn("dbo.AssetPurchaseDetail", "SubCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.AssetPurchaseDetail", "SubCategoryID");
            AddForeignKey("dbo.AssetPurchaseDetail", "SubCategoryID", "dbo.SubCategory", "SubCategoryID", cascadeDelete: true);
            DropColumn("dbo.AssetPurchaseDetail", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetPurchaseDetail", "CategoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.AssetPurchaseDetail", "SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "SubCategoryID" });
            DropColumn("dbo.AssetPurchaseDetail", "SubCategoryID");
            CreateIndex("dbo.AssetPurchaseDetail", "CategoryID");
            AddForeignKey("dbo.AssetPurchaseDetail", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
        }
    }
}
