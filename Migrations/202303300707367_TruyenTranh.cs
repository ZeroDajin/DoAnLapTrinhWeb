namespace DoAnWebTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruyenTranh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        IDChapter = c.Int(nullable: false, identity: true),
                        CSequence = c.Int(nullable: false),
                        IDManga = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDChapter)
                .ForeignKey("dbo.Truyens", t => t.IDManga)
                .Index(t => t.IDManga);
            
            CreateTable(
                "dbo.Truyens",
                c => new
                    {
                        IDManga = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Thumbnail = c.String(nullable: false),
                        IDTheLoai = c.Int(nullable: false),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.IDManga)
                .ForeignKey("dbo.TheLoais", t => t.IDTheLoai, cascadeDelete: true)
                .Index(t => t.IDTheLoai);
            
            CreateTable(
                "dbo.TheLoais",
                c => new
                    {
                        IDTheLoai = c.Int(nullable: false, identity: true),
                        TenTheLoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDTheLoai);
            
            CreateTable(
                "dbo.Trangs",
                c => new
                    {
                        IDTrang = c.String(nullable: false, maxLength: 128),
                        IDChapter = c.Int(nullable: false),
                        Image = c.String(),
                        TSequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDTrang)
                .ForeignKey("dbo.Chapters", t => t.IDChapter, cascadeDelete: true)
                .Index(t => t.IDChapter);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trangs", "IDChapter", "dbo.Chapters");
            DropForeignKey("dbo.Chapters", "IDManga", "dbo.Truyens");
            DropForeignKey("dbo.Truyens", "IDTheLoai", "dbo.TheLoais");
            DropIndex("dbo.Trangs", new[] { "IDChapter" });
            DropIndex("dbo.Truyens", new[] { "IDTheLoai" });
            DropIndex("dbo.Chapters", new[] { "IDManga" });
            DropTable("dbo.Trangs");
            DropTable("dbo.TheLoais");
            DropTable("dbo.Truyens");
            DropTable("dbo.Chapters");
        }
    }
}
