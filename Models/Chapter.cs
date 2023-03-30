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
        [Required]
        [Key]
        public int IDChapter { get; set; }
        [Required]
        public int CSequence { get; set; }
        [ForeignKey("Truyen")]
        public string IDManga { get; set; }
        public virtual Truyen Truyen { get; set; }
    }
}