using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoAnWebTruyenTranh.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<Truyen> Truyens { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Trang> Trangs { get; set; }
        public ApplicationDbContext()
            : base("DoAnLapTrinhWeb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}