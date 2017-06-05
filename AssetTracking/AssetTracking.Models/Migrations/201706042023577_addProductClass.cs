namespace AssetTracking.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProductClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        SubCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.Product", new[] { "SubCategoryID" });
            DropTable("dbo.Product");
        }
    }
}
