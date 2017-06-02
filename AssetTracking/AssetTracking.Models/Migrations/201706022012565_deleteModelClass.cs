namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteModelClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssetPurchaseSerialNumber", "AssetPurchaseDetailID", "dbo.AssetPurchaseDetail");
            DropIndex("dbo.AssetPurchaseSerialNumber", new[] { "AssetPurchaseDetailID" });
            DropTable("dbo.AssetPurchaseSerialNumber");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssetPurchaseSerialNumber",
                c => new
                    {
                        AssetPurchaseSerialNumberID = c.Int(nullable: false, identity: true),
                        AssetPurchaseDetailID = c.Int(nullable: false),
                        SerialNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AssetPurchaseSerialNumberID);
            
            CreateIndex("dbo.AssetPurchaseSerialNumber", "AssetPurchaseDetailID");
            AddForeignKey("dbo.AssetPurchaseSerialNumber", "AssetPurchaseDetailID", "dbo.AssetPurchaseDetail", "AssetPurchaseDetailID", cascadeDelete: true);
        }
    }
}
