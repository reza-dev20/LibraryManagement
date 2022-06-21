namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Users", "Family", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Users", "MobileNumber", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "MobileNumber", c => c.String(maxLength: 11));
            AlterColumn("dbo.Users", "Family", c => c.String(maxLength: 70));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 70));
        }
    }
}
