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
        /*khác với Thể Loại, ID của trang ảnh thì sử dụng identity được vì mình không cần
         * phải lập điều kiện với nó hay phụ thuộc vào nó.
        */
        [Key]
        [Required]
        public int IDTrang { get; set; }
        [ForeignKey("Chapter")]
        [Required]
        public int IDChapter { get; set; }

        public string Image { get; set; }
        [Required]
        public int TSequence { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}