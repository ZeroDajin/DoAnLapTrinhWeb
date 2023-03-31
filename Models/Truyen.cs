using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoAnWebTruyenTranh.Models
{
    public class Truyen
    {
        /* Sẽ cần 1 cái bảng chi tiết dành cho Manga để thể hiện toàn bộ thể loại của nó, tạm
         * thời sẽ chỉ có 1 thể loại.
         */
        [Required]
        [Key]
        public string IDManga { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [ForeignKey("TheLoai")]
        public int IDTheLoai { get; set; }
        public string Author { get; set; }
        public virtual TheLoai TheLoai { get; set; }


        public static List<Truyen> GetTruyens()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            return dbContext.Truyens.ToList();
        }
    }
}