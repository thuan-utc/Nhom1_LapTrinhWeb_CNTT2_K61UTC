using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
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

        [Route("addTour")]
        [HttpGet]
        public IActionResult AddTour()
        {
            ViewBag.MaNv = new SelectList(db.NhanViens.ToList(), "MaNv", "MaNv");
            return View();
        }

        [Route("addTour")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddTour(Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("ListTour");
            }
            return View(tour);
        }

        [Route("editTour")]
        [HttpGet]
        public IActionResult EditTour(string maTour)
        {
            ViewBag.MaNv = new SelectList(db.NhanViens.ToList(), "MaNv", "MaNv");
            var tour = db.Tours.Find(maTour);
            return View(tour);
        }

        [Route("editTour")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult EditTour(Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListTour");
            }
            return View(tour);
        }
    }
}
