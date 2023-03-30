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
        public string IDManga { get; set; }
        [Required]
        public string AnotherName { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [ForeignKey("TheLoai")]
        public int IDTheLoai { get; set; }
        public string Author { get; set; }
    }
}