using DoAnWebTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebTruyenTranh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(Truyen.GetTruyens());
        }
        public ActionResult XemTruyen(string id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var objs = _dbContext.Chapters.ToList();
            List<Chapter> chapters = objs.Where(x => x.IDManga == id).ToList();
                if(chapters == null)
            {
                return HttpNotFound();
            }
            return View(chapters);
        }
        public ActionResult XemChapter(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var objs = _dbContext.Trangs.ToList();
            List<Trang> trangs = objs.Where(x => x.IDChapter == id).ToList();
            if (trangs == null)
            {
                return HttpNotFound();
            }
            return View(trangs);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}