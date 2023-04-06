using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using Microsoft.EntityFrameworkCore;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Cooperator.Controllers
{
    [Area("cooperator")]
    [Route("cooperator")]

    public class HomeCooperatorController : Controller
    {
        TourManagementContext Tourdb = new TourManagementContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("historyAddTour")]
        public IActionResult LichSuAddTour()
        {
            var lstlichsu = Tourdb.Tours.ToList();
            return View(lstlichsu);
        }
        [Route("addtour")]
        [HttpGet]
        public IActionResult AddTour()
        {
            ViewBag.MaNv = new SelectList(Tourdb.NhanViens.ToList(),"MaNv","MaNv");
            return View();
        }

        [ValidateAntiForgeryToken]
        [Route("addtour")]
        [HttpPost]
        
        public IActionResult AddTour(Tour tour)
        {
            if (ModelState.IsValid)
            {
                Tourdb.Tours.Add(tour);
                Tourdb.SaveChanges();
                return RedirectToAction("historyAddTour");
            }
            return View(tour);
        }


        [Route("edittour")]
        public IActionResult EditTour(int etour)
        {
            var touredit = Tourdb.Tours.SingleOrDefault(x => x.MaTour == etour);
            ViewBag.MaNv = new SelectList(Tourdb.NhanViens, "MaNv", "MaNv");
           
            return View(touredit);
        }

        [Route("edittour")]
        [HttpPost]
        public IActionResult EditTour(Tour edtour)
        {
            var tour = Tourdb.Tours.Find(edtour.MaTour);
            if (ModelState.IsValid)
            {
                tour.MaNv = edtour.MaNv;
                tour.TenTour = edtour.TenTour;
                tour.ChiTietLt = edtour.ChiTietLt;
                tour.NgayBd = edtour.NgayBd;
                tour.NgayKt = edtour.NgayKt;
                tour.AnhTour = edtour.AnhTour;
                tour.Active = edtour.Active;
                tour.IsDeleted = edtour.IsDeleted;
                Tourdb.SaveChanges();
                return RedirectToAction("historyAddTour");
            }
            return View(edtour);
        }

        [Route("deleteTour")]
        public IActionResult DeleteTour(int matour)
        {
            var listtour = Tourdb.Tours.Where(x => x.MaTour == matour);
            foreach (var item in listtour)
            {
                if (Tourdb.NhanViens.Where(x => x.MaNv == item.MaNv) != null)
                {
                    return RedirectToAction("historyAddTour");
                }
            }
            if (listtour != null) Tourdb.RemoveRange(listtour);
            Tourdb.Remove(Tourdb.Tours.Find(matour));
            Tourdb.SaveChanges();
            return RedirectToAction("historyAddTour");
        }


    }
}

