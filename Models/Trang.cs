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
        public string IDTrang { get; set; }
        [ForeignKey("Chapter")]
        [Required]
        public string IDChapter { get; set; }

        public string Image { get; set; }
        [Required]
        public int TSequence { get; set; }
    }
}