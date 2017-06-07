namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetDAssetHModelClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit");
            DropForeignKey("dbo.AssetPurchaseDetail", "SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "SubCategoryID" });
            DropIndex("dbo.AssetPurchaseDetail", new[] { "WarrantyPeriodUnitID" });
            RenameColumn(table: "dbo.AssetPurchaseDetail", name: "SubCategoryID", newName: "SubCategory_SubCategoryID");
            AddColumn("dbo.AssetPurchaseDetail", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", c => c.Int());
            CreateIndex("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID");
            AddForeignKey("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", "dbo.SubCategory", "SubCategoryID");
            DropColumn("dbo.AssetPurchaseDetail", "AssetPurchaseDetailTitle");
            DropColumn("dbo.AssetPurchaseDetail", "IsWarranty");
            DropColumn("dbo.AssetPurchaseDetail", "WarrantyPeriod");
            DropColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", c => c.Int(nullable: false));
            AddColumn("dbo.AssetPurchaseDetail", "WarrantyPeriod", c => c.Double(nullable: false));
            AddColumn("dbo.AssetPurchaseDetail", "IsWarranty", c => c.Boolean(nullable: false));
            AddColumn("dbo.AssetPurchaseDetail", "AssetPurchaseDetailTitle", c => c.Int(nullable: false));
            DropForeignKey("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "SubCategory_SubCategoryID" });
            AlterColumn("dbo.AssetPurchaseDetail", "SubCategory_SubCategoryID", c => c.Int(nullable: false));
            DropColumn("dbo.AssetPurchaseDetail", "ProductID");
            RenameColumn(table: "dbo.AssetPurchaseDetail", name: "SubCategory_SubCategoryID", newName: "SubCategoryID");
            CreateIndex("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID");
            CreateIndex("dbo.AssetPurchaseDetail", "SubCategoryID");
            AddForeignKey("dbo.AssetPurchaseDetail", "SubCategoryID", "dbo.SubCategory", "SubCategoryID", cascadeDelete: true);
            AddForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit", "WarrantyPeriodUnitID", cascadeDelete: true);
        }
    }
}
