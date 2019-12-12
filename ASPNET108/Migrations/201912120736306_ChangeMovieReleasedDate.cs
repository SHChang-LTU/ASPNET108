namespace ASPNET108.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieReleasedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleasedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
        }
    }
}
