using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWebTruyenTranh.Models
{
    public class TheLoai
    {
        /*Lưu ý: sử dụng int trong thể loại nó bật identity thì vào tắt,
         * mặc dù nhập thông tin bằng tay vào bảng thì mệt nhưng sau này nhập
         * các dữ liệu khác dựa vào thể loại sẽ không bị rắc rối vụ identity on
         */
        [Key]
        [Required]
        public int IDTheLoai { get; set; }
        [Required]
        public string TenTheLoai { get; set; }
    }
}