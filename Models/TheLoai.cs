using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWebTruyenTranh.Models
{
    public class TheLoai
    {
        [Key]
        [Required]
        public int IDTheLoai { get; set; }
        public string TenTheLoai { get; set; }
    }
}