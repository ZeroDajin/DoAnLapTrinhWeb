namespace DoAnWebTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruyenTranh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapters", "CSequence", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapters", "CSequence");
        }
    }
}
