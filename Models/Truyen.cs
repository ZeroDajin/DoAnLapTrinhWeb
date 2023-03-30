using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWebTruyenTranh.Models
{
    public class Truyen
    {
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
    }
}