using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebTruyenTranh.Models
{
    public class Chapter
    {
        /* mặc dù trang ảnh vẫn cần ID của chapter để so sánh và truy xuất ảnh, sử dụng identity
         * tại chỗ này sẽ hữu dụng hơn do mình đã có sẵn IDChapter khi bấm vào chapter rồi.
        */
        [Required]
        [Key]
        public int IDChapter { get; set; }
        [Required]
        public int CSequence { get; set; }
        [ForeignKey("Truyen")]
        public string IDManga { get; set; }
        public virtual Truyen Truyen { get; set; }

        //public static List<Chapter> GetChapters()
        //{
        //    ApplicationDbContext dbContext = new ApplicationDbContext();
        //    return obj;
        //}
    }
}