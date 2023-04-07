using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using System.Diagnostics;
using X.PagedList;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Controllers
{
    public class HomeController : Controller
    {
      
        TourManagementContext tour = new TourManagementContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		
		public IActionResult Index(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			var listTour = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			return View(lst);
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