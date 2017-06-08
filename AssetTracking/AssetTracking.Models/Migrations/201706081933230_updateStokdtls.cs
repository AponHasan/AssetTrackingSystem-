namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStokdtls : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AssetPurchaseDetail", "ProductID");
            AddForeignKey("dbo.AssetPurchaseDetail", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetPurchaseDetail", "ProductID", "dbo.Product");
            DropIndex("dbo.AssetPurchaseDetail", new[] { "ProductID" });
        }
    }
}
