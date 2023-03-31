namespace DoAnWebTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAllTruyenValues1 : DbMigration
    {
        public override void Up()
        
            {
                //Thêm vào bảng thể loại
                Sql("INSERT INTO TheLoais (TenTheLoai) VALUES('ACTION')");
                Sql("INSERT INTO TheLoais (TenTheLoai) VALUES('MYSTERY')");
                Sql("INSERT INTO TheLoais (TenTheLoai) VALUES('HAREM')");
                //Thêm vào bảng truyện
                // Sql("INSERT INTO Truyens (IDManga, Name, Thumbnail, IDTheLoai, Author) VALUES('KageNoJitsuryokusha', 'Kage no Jitsuryokusha','D:\\Zero\\Study\\Lap Trinh Web\\LT\\DoAn\\Truyen\\KagenoJitsuryokusha\\Thumbnail.jpg',1,'Bruh')");
                //Thêm vào bảng Chapter
                //Sql("INSERT INTO Chapters (CSequence, IDManga) VALUES(1,'KageNoJitsuryokusha')");
                //Thêm vào bảng trang
                //Sql("INSERT INTO Trangs (IDTrang, IDChapter, Image, TSequence) VALUES('D:\\Zero\\Study\\Lap Trinh Web\\LT\\DoAn\\Truyen\\KagenoJitsuryokusha\\001\\001.jpg',1)");
                // Sql("INSERT INTO Trangs (IDTrang, IDChapter, Image, TSequence) VALUES('D:\\Zero\\Study\\Lap Trinh Web\\LT\\DoAn\\Truyen\\KagenoJitsuryokusha\\001\\002.jpg',2)");
                // Sql("INSERT INTO Trangs (IDTrang, IDChapter, Image, TSequence) VALUES('D:\\Zero\\Study\\Lap Trinh Web\\LT\\DoAn\\Truyen\\KagenoJitsuryokusha\\001\\003.jpg',3)");
            }


        public override void Down()
        {
        }
    }
}
