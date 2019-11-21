namespace ASPNET108.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreditAndBirthdateToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "Credit", c => c.Short(nullable: false));
            DropColumn("dbo.Customers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Phone", c => c.String());
            DropColumn("dbo.Customers", "Credit");
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
