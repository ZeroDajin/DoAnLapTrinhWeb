namespace DoAnWebTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trangs", "TSequence", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trangs", "TSequence");
        }
    }
}
