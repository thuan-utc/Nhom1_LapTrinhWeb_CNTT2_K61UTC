using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
	[Route("homeadmin")]
	public class HomeAdminController : Controller
    {
        TourManagementContext db = new TourManagementContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("listTour")]
        public IActionResult ListTour()
        {
            var lstTour = db.Tours.ToList();
            return View(lstTour);
        }

        [Route("editTour")]
        [HttpGet]
        public IActionResult EditTour(int maTour)
        {
            var touredit = db.Tours.SingleOrDefault(x => x.MaTour == maTour);
            ViewBag.MaNv = new SelectList(db.NhanViens, "MaNv", "MaNv");

            return View(touredit);
        }

        [Route("editTour")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult EditTour(Tour edTour)
        {
            var tour = db.Tours.Find(edTour.MaTour);
            if (ModelState.IsValid)
            {
                tour.MaNv = edTour.MaNv;
                tour.TenTour = edTour.TenTour;
                tour.ChiTietLt = edTour.ChiTietLt;
                tour.NgayBd = edTour.NgayBd;
                tour.NgayKt = edTour.NgayKt;
                tour.AnhTour = edTour.AnhTour;
                tour.Active = edTour.Active;
                tour.IsDeleted = edTour.IsDeleted;
                db.SaveChanges();
                return RedirectToAction("ListTour");
            }
            return View(edTour);
        }

        //public IActionResult DetailTour(int maTour)
        //{
        //    var tour = db.Tours.SingleOrDefault(x => x.MaTour == maTour);
        //    var imgTour = db.AnhTours.Where(x => x.MaTour == maTour).ToList();
        //    ViewBag.imgTour = imgTour;
        //    return View(tour);
        //}

        [Route("listCooperator")]
        [HttpGet]
        public IActionResult ListCooperator(Tour tour)
        {
            var lstCooperator = db.DaiLies.ToList();
            return View(lstCooperator);
        }

        //[Route("editCooperator")]
        //[HttpGet]
        //public IActionResult EditCooperator(string maDaily)
        //{
        //    ViewBag.MaNv = new SelectList(db.NhanViens.ToList(), "MaNv", "MaNv");
        //    var tour = db.Tours.Find(maDaily);
        //    return View(tour);
        //}

        //[Route("editCooperator")]
        //[HttpPost]
        //public IActionResult EditCooperator(Tour tour)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tour).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("ListCooperator");
        //    }
        //    return View(tour);
        //}

        //public IActionResult DetailCooperator(int maDaily)
        //{
        //    var tour = db.Tours.SingleOrDefault(x => x.MaTour == maDaily);
        //    var imgTour = db.AnhTours.Where(x => x.MaTour == maDaily).ToList();
        //    ViewBag.imgTour = imgTour;
        //    return View(tour);
        //}
    }
}
