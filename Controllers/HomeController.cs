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
        public ActionResult XemTruyen(int? id)
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
            Chapter objc = _dbContext.Chapters.Where(x=> x.IDChapter == id).First();
            var objm = _dbContext.Chapters.Where(x => x.IDManga == objc.IDManga).ToList();
            ChapterViewModel ChapterDATA = new ChapterViewModel();
            var objt = _dbContext.Trangs.ToList();
            List<Trang> trangs = objt.Where(x => x.IDChapter == id).ToList();
            ChapterDATA.Trangs = trangs;
            ChapterDATA.Chapters= objm ;
            ChapterDATA.CurrentMangaID = objc.IDManga;
            ChapterDATA.CurrentCSequence = objc.CSequence;
            ChapterDATA.TotalChapters = objm.Count();
            if (trangs == null)
            {
                return HttpNotFound();
            }
            return View(ChapterDATA);
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