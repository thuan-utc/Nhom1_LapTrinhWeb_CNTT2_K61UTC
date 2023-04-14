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

        [Route("deleteTour")]
        [HttpGet]
        public IActionResult DeleteTour(int maTour)
        {
            var tour = db.Tours.Where(x => x.MaTour == maTour).ToList();
            if (tour.Count() > 0)
            {
                return RedirectToAction("ListTour", "admin");
            }
            var anhTour = db.AnhTours.Where(x => x.MaTour == maTour).ToList();
            if (anhTour.Any()) db.RemoveRange(anhTour);
            db.Remove(db.Tours.Find(maTour));
            db.SaveChanges();
            return RedirectToAction("ListTour", "admin");
        }

        [Route("listCooperator")]
        [HttpGet]
        public IActionResult ListCooperator()
        {
            var lstCooperator = db.DaiLies.ToList();
            return View(lstCooperator);
        }

        [Route("editCooperator")]
        [HttpGet]
        public IActionResult EditCooperator(int maDaily)
        {
            var daiLy = db.DaiLies.Find(maDaily);
            return View(daiLy);
        }

        [Route("editCooperator")]
        [HttpPost]
        public IActionResult EditCooperator(DaiLy daiLy)
        {
            var dl = db.DaiLies.Find(daiLy.MaDaiLy);
            if (ModelState.IsValid)
            {
                dl.MaDaiLy = daiLy.MaDaiLy;
                dl.TenDaiLy = daiLy.TenDaiLy;
                dl.Sdt = daiLy.Sdt;
                dl.DiaChi = daiLy.DiaChi;
                db.SaveChanges();
                return RedirectToAction("ListCooperator");
            }
            return View(daiLy);
        }

        [Route("deleteCooperator")]
        [HttpGet]
        public IActionResult DeleteCooperator(int maDaily)
        {
            var daily = db.DaiLies.Where(x => x.MaDaiLy == maDaily).ToList();
            if (daily.Count() > 0)
            {
                return RedirectToAction("ListCooperator", "admin");
            }
            db.Remove(db.DaiLies.Find(maDaily));
            db.SaveChanges();
            return RedirectToAction("ListCooperator", "admin");
        }

    }
}
