namespace ASPNET108.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateNullableToCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
