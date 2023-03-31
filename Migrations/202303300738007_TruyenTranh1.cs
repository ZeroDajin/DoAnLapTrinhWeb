namespace DoAnWebTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruyenTranh1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Trangs");
            AlterColumn("dbo.Trangs", "IDTrang", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Trangs", "IDTrang");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Trangs");
            AlterColumn("dbo.Trangs", "IDTrang", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Trangs", "IDTrang");
        }
    }
}
