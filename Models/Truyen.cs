using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int IDTheLoai { get; set; }
        public string Author { get; set; }
        public IEnumerable<IDTheLoai>  TheLoais{ get; set; }
    }
}