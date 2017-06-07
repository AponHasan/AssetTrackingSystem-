namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetDAssetHcHange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "SubCategory_SubCategoryID" });
            DropColumn("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", c => c.Int());
            CreateIndex("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID");
            AddForeignKey("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", "dbo.SubCategory", "SubCategoryID");
        }
    }
}
