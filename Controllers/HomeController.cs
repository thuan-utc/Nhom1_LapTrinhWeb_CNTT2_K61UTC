using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using System.Diagnostics;
using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Controllers
{
	public class HomeController : Controller
	{

		QltnContext tour = new QltnContext();
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}


		public IActionResult Index(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours;
			var listSanPham = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			return View(lst);

		}
		public IActionResult Package(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours;
			var listSanPham = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listSanPham, pageNumber, pageSize);
			return View(lst);
		}
		public IActionResult TourDetail(int matour)
		{
			var sanpham = tour.Tours.SingleOrDefault(x => x.MaTour == matour);
			var anhtour = tour.AnhTours.Where(x => x.MaTour == matour).ToList();
			ViewBag.anhtour = anhtour.ToList();
			return View(sanpham);
		}
		public IActionResult Booking(int matour)
		{
			var result = from tours in tour.Tours
						 join cttour in tour.Cttours on tours.MaTour equals cttour.MaTour
						 where tours.MaTour == matour
						 select new Booking
						 {
							 TenTour = tours.TenTour,
							 ThoiGian = cttour.ThoiGian,
							 DiemTq=cttour.ĐiemTq,
							 AmThuc=cttour.AmThuc,
							 PhuongTien=cttour.PhuongTien,
							 KhachSan=cttour.KhachSan,
							 DoiTuongTh=cttour.DoiTuongTh,
							 UuDai=cttour.UuDai,
						 };
		
			return View(result.ToList());
		}
	


		public IActionResult Privacy()
        {
            return View();
            ///////
        }
        [HttpGet]
        public IActionResult LoginCustumer()
        {
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}