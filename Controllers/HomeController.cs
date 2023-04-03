using DoAnWebTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            Chapter objc = _dbContext.Chapters.Where(x => x.IDChapter == id).First();
            var objm = _dbContext.Chapters.Where(x => x.IDManga == objc.IDManga).ToList();
            ChapterViewModel ChapterDATA = new ChapterViewModel();
            var objt = _dbContext.Trangs.ToList();
            List<Trang> trangs = objt.Where(x => x.IDChapter == id).ToList();
            ChapterDATA.Trangs = trangs;
            ChapterDATA.Chapters = objm;
            ChapterDATA.CurrentMangaID = objc.IDManga;
            ChapterDATA.CurrentCSequence = objc.CSequence;
            ChapterDATA.TotalChapters = objm.Count();
            if (trangs == null)
            {
                return HttpNotFound();
            }
            return View(ChapterDATA);
        }
            public ActionResult SuaTruyen(int id)
            {
                if (id == null||id==0)
                {
                    return HttpNotFound();
                }
                var objc = _dbContext.Chapters.Where(x => x.IDManga == id).ToList();
                return View(objc);
            }
        [HttpGet]
        public ActionResult Create(int id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var objm = dbContext.Truyens.Where(x => x.IDManga == id).First();
            var objc = dbContext.Chapters.Where(x => x.IDManga == id).ToList();
            var ThemChapterV = new SuaTruyenViewModel
            {
                IDManga = id,
                NameManga = objm.Name,
                TotalChapters = objc.Count()
            };
            return View(ThemChapterV);
        }
        [HttpPost]
        public ActionResult Create(SuaTruyenViewModel newchapter)
        {
            if(newchapter.IDManga ==null||newchapter.IDManga==0)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                var chapter = new Chapter
                {
                    IDManga = newchapter.IDManga,
                    CSequence = newchapter.CSequence
                };
                dbContext.Chapters.Add(chapter);
                dbContext.SaveChanges();
                var ReferChapter = dbContext.Chapters.Where(x => x.IDManga == newchapter.IDManga).ToList().OrderBy(x=>x.CSequence).Last();
                var trang = new Trang
                {
                    IDChapter = ReferChapter.IDChapter,
                    TSequence = 1
                };
                dbContext.Trangs.Add(trang);
                dbContext.SaveChanges();
                return View("SuaTruyen", Chapter.GetChapters());
            }
            else
            {
                return View("Create",newchapter);
            }
        }
        public ActionResult SuaChapters(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var objt = dbContext.Trangs.Where(x => x.IDChapter == id).ToList();
            return View(objt);
        }
        [HttpGet]
        public ActionResult CreateTrang(int id)
        {
            Trang objt = new Trang
            {
                IDChapter = id
            };
            return View(objt);
        }
        [HttpPost]
        public ActionResult CreateTrang(Trang newTrang)
        {
            if(ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                dbContext.Trangs.Add(newTrang);
                dbContext.SaveChanges();
                return View("SuaChapters", Trang.GetTrangs(newTrang.IDChapter));
            }
            else
            {
                return View("CreateTrang", newTrang);
            }
        }
        public ActionResult EditTrang(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var find = dbContext.Trangs.Where(x => x.IDTrang == id).First();
            if(find == null)
            {
                return HttpNotFound();
            }
            return View(find);
        }
        [HttpPost]
        public ActionResult EditTrang(Trang editedtrang)
        {
            if(ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                Trang trang = dbContext.Trangs.FirstOrDefault(p => p.IDTrang == editedtrang.IDTrang);
                if(trang != null)
                {
                    trang.IDChapter = editedtrang.IDChapter;
                    trang.Image = editedtrang.Image;
                    trang.TSequence = editedtrang.TSequence;
                    dbContext.Trangs.AddOrUpdate(trang);
                    dbContext.SaveChanges();
                    return View("SuaChapters", Trang.GetTrangs(editedtrang.IDChapter));
                }
                else
                {
                    return View("SuaChapters", Trang.GetTrangs(editedtrang.IDChapter));
                }
            }
            else
            {
                return View("EditTrang", editedtrang);
            }
        }
        public ActionResult DeleteTrang(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            
            var find = dbContext.Trangs.Where(x => x.IDTrang == id).First();
            if (find == null)
            {
                return HttpNotFound();
            }
            var countTrangs = dbContext.Trangs.Where(x=> x.IDChapter == find.IDChapter).Count();
            if (countTrangs > 1)
            {
                return View(find);
            }
            else
            {
                return View("SuaChapters", Trang.GetTrangs(find.IDChapter));
            }
        }
        [HttpPost]
        public ActionResult DeleteTrang(int id, FormCollection collection)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Trang trang = dbContext.Trangs.FirstOrDefault(x => x.IDTrang == id);
            int IDChapter = trang.IDChapter;
            if (trang == null)
            {
                return HttpNotFound();
            }
            dbContext.Trangs.Remove(trang);
            dbContext.SaveChanges();
            return View("SuaChapters", Trang.GetTrangs(IDChapter));
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