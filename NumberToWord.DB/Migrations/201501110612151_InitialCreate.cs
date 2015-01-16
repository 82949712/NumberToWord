namespace NumberToWord.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calculation", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calculation", "LastModified");
        }
    }
}
