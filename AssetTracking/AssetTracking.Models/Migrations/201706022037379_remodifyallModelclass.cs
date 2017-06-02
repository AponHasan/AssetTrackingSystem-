namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remodifyallModelclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnit_WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "WarrantyPeriodUnit_WarrantyPeriodUnitID" });
            DropColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID");
            RenameColumn(table: "dbo.AssetPurchaseDetail", name: "WarrantyPeriodUnit_WarrantyPeriodUnitID", newName: "WarrantyPeriodUnitID");
            AddColumn("dbo.AssetPurchaseDetail", "AssetPurchaseDetailTitle", c => c.Int(nullable: false));
            AlterColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", c => c.Int(nullable: false));
            AlterColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", c => c.Int(nullable: false));
            CreateIndex("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID");
            CreateIndex("dbo.AssetPurchaseHeader", "VendorID");
            AddForeignKey("dbo.AssetPurchaseHeader", "VendorID", "dbo.Vendor", "VendorID", cascadeDelete: true);
            AddForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit", "WarrantyPeriodUnitID", cascadeDelete: true);
            DropColumn("dbo.AssetPurchaseHeader", "PurchasedBy");
            DropColumn("dbo.AssetPurchaseHeader", "CreatedBy");
            DropColumn("dbo.AssetPurchaseHeader", "LastModifiedBy");
            DropColumn("dbo.AssetPurchaseHeader", "LastModifiedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetPurchaseHeader", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.AssetPurchaseHeader", "LastModifiedBy", c => c.Int());
            AddColumn("dbo.AssetPurchaseHeader", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.AssetPurchaseHeader", "PurchasedBy", c => c.Int(nullable: false));
            DropForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit");
            DropForeignKey("dbo.AssetPurchaseHeader", "VendorID", "dbo.Vendor");
            DropIndex("dbo.AssetPurchaseHeader", new[] { "VendorID" });
            DropIndex("dbo.AssetPurchaseDetail", new[] { "WarrantyPeriodUnitID" });
            AlterColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", c => c.Int());
            AlterColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", c => c.Double(nullable: false));
            DropColumn("dbo.AssetPurchaseDetail", "AssetPurchaseDetailTitle");
            RenameColumn(table: "dbo.AssetPurchaseDetail", name: "WarrantyPeriodUnitID", newName: "WarrantyPeriodUnit_WarrantyPeriodUnitID");
            AddColumn("dbo.AssetPurchaseDetail", "WarrantyPeriodUnitID", c => c.Double(nullable: false));
            CreateIndex("dbo.AssetPurchaseDetail", "WarrantyPeriodUnit_WarrantyPeriodUnitID");
            AddForeignKey("dbo.AssetPurchaseDetail", "WarrantyPeriodUnit_WarrantyPeriodUnitID", "dbo.WarrantyPeriodUnit", "WarrantyPeriodUnitID");
        }
    }
}
