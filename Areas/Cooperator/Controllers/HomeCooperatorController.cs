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
        public IActionResult LichSuAddTour(string price )
        {
            var lstlichsu = Tourdb.Tours.ToList();
            if (price == "all")
            {
                lstlichsu = Tourdb.Tours.AsNoTracking().ToList();
            }
            if (price == "above")
            {
                lstlichsu = Tourdb.Tours.AsNoTracking().Where(x => x.Gia > 5000000).ToList();
            }
            else if (price == "below")
            {
                lstlichsu = Tourdb.Tours.AsNoTracking().Where(x => x.Gia <= 5000000).ToList();
            }
            return View(lstlichsu);
        }
        [Route("listbooktour")]
        public IActionResult KHTheoTour(int khtour)
        {
            var kh = (from c in Tourdb.KhachHangs
                      join t in Tourdb.HoaDons on c.MaKh equals t.MaKh
                      join q in Tourdb.Tours on t.MaTour equals q.MaTour
                      where q.MaTour == khtour
                      select c);
            return View(kh);
        }


        [Route("addtour")]
        [HttpGet]
        public IActionResult AddTour()
        {
            ViewBag.MaNv = new SelectList(Tourdb.NhanViens.ToList(),"MaNv","MaNv");
            ViewBag.MaQg = new SelectList(Tourdb.TquocGia, "MaQg", "TenQg");
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
            ViewBag.MaQg = new SelectList(Tourdb.TquocGia, "MaQg", "TenQg");
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
        //Custormer//////////////////
        [Route("listcustomer")]
        public IActionResult ListCustomer()
        {
            var lstlichsu = Tourdb.KhachHangs.ToList();
            return View(lstlichsu);
        }


        [Route("editcustomer")]
        public IActionResult EditCustomer(int ecus)
        {
            var khedit = Tourdb.KhachHangs.SingleOrDefault(x => x.MaKh == ecus);
            return View(khedit);
        }

        [Route("editcustomer")]
        [HttpPost]
        public IActionResult EditCustomer(KhachHang ecus)
        {
            var cus = Tourdb.KhachHangs.Find(ecus.MaKh);
            if (ModelState.IsValid)
            {
                cus.MaKh = ecus.MaKh;
                cus.TenKh = ecus.TenKh;
                cus.SoCmnd = ecus.SoCmnd;
                cus.Sdt = cus.Sdt;
                cus.DiaChi = ecus.DiaChi;
                cus.AnhKh = ecus.AnhKh;
                cus.IsDeleted = ecus.IsDeleted;
                Tourdb.SaveChanges();
                return RedirectToAction("listcustomer");
            }
            return View(ecus);
        }


        [Route("deleteCustomer")]
        public IActionResult DeleteCustomer(int makh)
        {
            // Lấy danh sách customer cần xóa dựa trên mã tour
            var listtour = Tourdb.KhachHangs.Where(x => x.MaKh == makh);

            

            // Xóa các tour trong danh sách và lưu thay đổi
            if (listtour != null)
            {
                Tourdb.RemoveRange(listtour);
                Tourdb.SaveChanges();
            }

            // Xóa tour dựa trên mã tour và lưu thay đổi
            var kh = Tourdb.KhachHangs.Find(makh);
            if (kh != null)
            {
                Tourdb.Remove(kh);
                Tourdb.SaveChanges();
            }

            // Chuyển hướng đến trang lịch sử thêm tour
            return RedirectToAction("listcustomer");
        }
        ////////Hoa don
        [Route("listbill")]
        public IActionResult ListBill()
        {
            var lstbill = Tourdb.HoaDons.ToList();
            return View(lstbill);
        }

        



        [Route("deleteBill")]
        public IActionResult DeleteBill(int mahd, int matr, int makh, int madl)
        {
            // Lấy danh sách hóa đơn cần xóa dựa trên mã hóa đơn
            var listhd = Tourdb.HoaDons.Where(x => x.MaHd == mahd);

            // Kiểm tra xem các đối tượng có tồn tại trong CSDL hay không
            var tours = Tourdb.Tours.Find(matr);
            var cus = Tourdb.KhachHangs.Find(makh);
            var agency = Tourdb.DaiLies.Find(madl);
            if (tours == null || cus == null || agency == null)
            {
                return RedirectToAction("listbill");
            }

            // Xóa các hóa đơn trong danh sách và lưu thay đổi
            if (listhd != null)
            {
                Tourdb.RemoveRange(listhd);
                Tourdb.SaveChanges();
            }

            // Xóa các đối tượng dựa trên các mã tương ứng và lưu thay đổi
            var hd = Tourdb.HoaDons.Find(mahd);
            if (hd != null)
            {
                Tourdb.Remove(hd);
            }
            var tour = Tourdb.Tours.Find(matr);
            if (tour != null)
            {
                Tourdb.Remove(tour);
            }
            var kh = Tourdb.KhachHangs.Find(makh);
            if (kh != null)
            {
                Tourdb.Remove(kh);
            }
            var dl = Tourdb.DaiLies.Find(madl);
            if (dl != null)
            {
                Tourdb.Remove(dl);
            }

            Tourdb.SaveChanges();

            // Chuyển hướng đến trang danh sách hóa đơn
            return RedirectToAction("listbill");
        }




    }
}

