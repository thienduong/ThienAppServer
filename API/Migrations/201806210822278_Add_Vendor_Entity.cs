namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Vendor_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            var sqlStrOn = "SET IDENTITY_INSERT Vendors ON";
            var sqlStrInsert = "insert into Vendors (Id, Name) values (1, 'Vendor 1')";
            Sql(sqlStrOn);
            Sql(sqlStrInsert);

            AddColumn("dbo.Products", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "VendorId");
            var sqlStr = "update Products set VendorId = 1";
            var sqlStrOff = "SET IDENTITY_INSERT Vendors OFF";
            Sql(sqlStr);
            Sql(sqlStrOff);

            AddForeignKey("dbo.Products", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            DropColumn("dbo.Products", "VendorId");
            DropTable("dbo.Vendors");
        }
    }
}
