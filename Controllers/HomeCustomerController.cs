using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using Nhom1_LapTrinhWeb_CNTT2_K61.Repository;
using X.PagedList;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Controllers
{
    [Route("customer")]
	public class HomeCustomerController : Controller
	{
		TourManagementContext tour = new TourManagementContext();
		private readonly ILogger<HomeController> _logger;
		[Route("index")]
		[Route("")]
		public IActionResult Index(int?page)
		{
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            int pageSize = 9;
            var listTour = tour.Tours;
            var listSanPham = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
            PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
            return View(lst);
        }
		[Route("packages")]
		public IActionResult Packages(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours;
			var listSanPham = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			return View(lst);
		}
		[Route("tourThaiLan")]
		public IActionResult TourThaiLan(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours.AsNoTracking().Where(x => x.MaQg == 6).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg=6;
			return View(lst);
		}
		[Route("tourSingapore")]
		public IActionResult TourSingapore(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours.AsNoTracking().Where(x => x.MaQg == 9).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg=9;
			return View(lst);
		}
		[Route("tourChina")]
		public IActionResult TourChina(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours.AsNoTracking().Where(x => x.MaQg == 1).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg=1;
			return View(lst);
		}
		[Route("tourAnh")]
		public IActionResult TourAnh(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours.AsNoTracking().Where(x => x.MaQg ==5).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			ViewBag.MaQg = 5;
			return View(lst);
		}


		[Route("tourDetail")]

		public IActionResult TourDetail(int matour)
		{
			var sanpham = tour.Tours.SingleOrDefault(x => x.MaTour == matour);
			if (sanpham == null)
			{
				return NotFound();
			}

			ViewData["TourId"] = sanpham.MaTour;
			ViewData["TourName"] = sanpham.TenTour;
			ViewData["TourImage"] = "../Media/ImagesTour/" + sanpham.AnhTour + ".jpg";
			ViewBag.sanpham = sanpham;
			return View(sanpham);
		}
		[Route("booking")]
		public IActionResult Booking(int tourId)
		{
			var tourDetails = (from t in tour.Tours
							   join ct in tour.Cttours on t.MaTour equals ct.MaTour
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
								   ct.UuDai
							   }).ToList();
			ViewBag.TourDetails = tourDetails;
			return View();
		}
		[Route("tourTheoQuocGia")]
		public IActionResult TourTheoQuocGia(int Maqg, int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listSanPham = tour.Tours.AsNoTracking().Where(x => x.MaQg == Maqg).ToList();
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			ViewBag.MaQg = Maqg;
			return View(lst);
		}


		[Route("search")]
		public IActionResult Search(TourSearchModel model, int? page)
		{
			var tours = tour.Tours
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
