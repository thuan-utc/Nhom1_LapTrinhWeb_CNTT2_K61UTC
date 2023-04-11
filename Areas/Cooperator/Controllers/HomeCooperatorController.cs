using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Cooperator.Controllers
{
    [Area("cooperator")]
    [Route("homecooperator")]

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
        [Route("listbooktour")]
        public IActionResult KHTheoTour(int khtour)
        {
            var kh = (from c in Tourdb.KhachHangs
                     join t in Tourdb.HoaDons on c.MaKh equals t.MaKh
                     join q in Tourdb.Tours on t.MaTour equals q.MaTour
                     where q.MaTour == khtour
                     select new Product
                     {
                         TenKh = c.TenKh,
                         Sdt = c.Sdt,
                    });
            ViewBag.kh = kh;
            return View();
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
        public IActionResult DeleteTour(int matour, int manv)
        {
            // Lấy danh sách tour cần xóa dựa trên mã tour
            var listtour = Tourdb.Tours.Where(x => x.MaTour == matour);

            // Kiểm tra xem mã nhân viên có tồn tại trong danh sách tour hay không
            var nhanvien = Tourdb.NhanViens.Where(x => x.MaNv == manv).FirstOrDefault();
            if (nhanvien != null)
            {
                foreach (var item in listtour)
                {
                    if (item.MaNv == manv)
                    {
                        return RedirectToAction("historyAddTour");
                    }
                }
            }

            // Xóa các tour trong danh sách và lưu thay đổi
            if (listtour != null)
            {
                Tourdb.RemoveRange(listtour);
                Tourdb.SaveChanges();
            }

            // Xóa tour dựa trên mã tour và lưu thay đổi
            var tour = Tourdb.Tours.Find(matour);
            if (tour != null && tour.MaNv == manv)
            {
                Tourdb.Remove(tour);
                Tourdb.SaveChanges();
            }

            // Chuyển hướng đến trang lịch sử thêm tour
            return RedirectToAction("historyAddTour");
        }


    }
}

