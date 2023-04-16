using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using Nhom1_LapTrinhWeb_CNTT2_K61.Repository;
using NuGet.Versioning;
using X.PagedList;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Controllers
{
    [Route("customer")]
	public class HomeCustomerController : Controller
	{
		TourManagementContext tourDb = new TourManagementContext();
		private readonly ILogger<HomeController> _logger;
		[Route("index")]
		[Route("")]
		public IActionResult Index(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tourDb.Tours;
			var listSanPham = tourDb.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			return View(lst);
		}
		[Route("packages")]
		public IActionResult Packages(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tourDb.Tours;
			var listSanPham = tourDb.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			return View(lst);
		}
		[Route("tourThaiLan")]
		public IActionResult TourThaiLan(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tourDb.Tours.AsNoTracking().Where(x => x.MaQg == 6).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg = 6;
			return View(lst);
		}
		[Route("tourSingapore")]
		public IActionResult TourSingapore(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tourDb.Tours.AsNoTracking().Where(x => x.MaQg == 9).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg = 9;
			return View(lst);
		}
		[Route("tourChina")]
		public IActionResult TourChina(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tourDb.Tours.AsNoTracking().Where(x => x.MaQg == 1).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg = 1;
			return View(lst);
		}
		[Route("tourAnh")]
		public IActionResult TourAnh(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tourDb.Tours.AsNoTracking().Where(x => x.MaQg == 5).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg = 5;
			return View(lst);
		}


		[Route("tourDetail")]

		public IActionResult TourDetail(int matour)
		{
			var tourDetail = (from t in tourDb.Tours
							   join ct in tourDb.Cttours on t.MaTour equals ct.MaTour
							   where t.MaTour.Equals(matour)
							   select new { Tour = t, Cttour = ct }).ToList();
			ViewBag.TourDetail = tourDetail;
			return View();
		}
		[Route("booking")]
		[HttpGet]
		public IActionResult Booking(int tourId)
		{
			var tourDetail = (from t in tourDb.Tours
							   join ct in tourDb.Cttours on t.MaTour equals ct.MaTour
							   where t.MaTour == tourId
							   select new
							   {
								   t.MaTour,
								   t.TenTour,
								   t.Gia,
								   ct.ThoiGian,
								   ct.KhachSan,
								   ct.AmThuc,
								   ct.PhuongTien,
								   ct.DoiTuongTh,
								   ct.UuDai,
								   t.AnhTour,
								   t.NgayBd,
								   t.NgayKt
							   }).ToList();	
			ViewBag.tourDetail = tourDetail;
			ViewBag.khachHang = getCurrentUser();
			return View();
		}

		[Route("booking")]
		[HttpPost]
        public IActionResult Booking([FromForm] BookingModel bookingModel, int tourId)
        {
            if (bookingModel.SoVe <= 0)
            {
                return BadRequest();
            }
            var tour = tourDb.Tours.SingleOrDefault(t => t.MaTour == tourId);
            if (tour == null)
            {
                return BadRequest();
            }
            var kh = getCurrentUser();
            var hd = new HoaDon
            {
                MaKh = kh.MaKh,
                MaTour = tour.MaTour,
                MaDaiLy = tour.MaDaiLy
            };
            tourDb.HoaDons.Add(hd);
            tourDb.SaveChanges();
            return View();
        }


        private KhachHang getCurrentUser()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var khachhang = (from kh in tourDb.KhachHangs
                             join tk in tourDb.TaiKhoans on kh.MaKh equals tk.MaKh
                             where String.Equals(tk.Taikhoan1, userName)
                             select kh).ToList();
			return khachhang[0];
        }

        [Route("tourTheoQuocGia")]
		public IActionResult TourTheoQuocGia(int Maqg, int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listSanPham = tourDb.Tours.AsNoTracking().Where(x => x.MaQg == Maqg).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			ViewBag.MaQg = Maqg;
			return View(lst);
		}


		[Route("search")]
		public IActionResult Search(TourSearchModel model, int? page)
		{
			var tours = tourDb.Tours
				.Where(t => t.NoiKhoiHanh == model.From
							&& t.DiaDiem == model.To
							&& t.NgayBd >= model.Checkin
							&& t.NgayKt <= model.Checkout)
				.ToList();
			int pageSize = 10;
			int pageNumber = (page ?? 1);
			var pagedTours = tours.ToPagedList(pageNumber, pageSize);

			return View(pagedTours);
		}

		[Route("aboutUs")]
		public IActionResult AboutUs()
		{
			return View();
		}

		[Route("contact")]
		public IActionResult Contact()
		{
			return View();
		}

		[Route("services")]
		public IActionResult Services()
		{
			return View();
		}
	}
}
