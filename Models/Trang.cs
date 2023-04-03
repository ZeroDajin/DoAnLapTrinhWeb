using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebTruyenTranh.Models
{
    public class Trang
    {
        [Key]
        [Required]
        public int IDTrang { get; set; }
        [ForeignKey("Chapter")]
        [Required]
        public int IDChapter { get; set; }
        public string Image { get; set; }
        public int TSequence { get; set; }
        public virtual Chapter Chapter { get; set; }
        public static List<Trang> GetTrangs(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            return dbContext.Trangs.Where(x=>x.IDChapter==id).ToList();
        }
    }
}