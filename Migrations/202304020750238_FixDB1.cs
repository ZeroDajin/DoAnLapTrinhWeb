namespace DoAnWebTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Chapters", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chapters", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
