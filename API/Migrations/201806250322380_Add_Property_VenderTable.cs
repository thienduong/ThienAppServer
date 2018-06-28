namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Property_VenderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Address", c => c.String());
            AddColumn("dbo.Vendors", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendors", "PhoneNumber");
            DropColumn("dbo.Vendors", "Address");
        }
    }
}
