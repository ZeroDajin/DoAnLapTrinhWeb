using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebTruyenTranh.Models
{
    public class Chapter
    {
        [Required]
        public int IDChapter { get; set; }
        public string IDManga { get; set; }
        public string Images { get; set; }
    }
}