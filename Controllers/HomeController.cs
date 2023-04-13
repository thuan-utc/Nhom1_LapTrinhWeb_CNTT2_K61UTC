using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [Route("index")]
		[Route("")]
		public IActionResult Index(int? page)
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 4;
			var listTour = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			return View(lst);

		}

        public IActionResult AboutUs()
        {
            return View();
        }
		public IActionResult Cooperate()
		{
			return View();
		}
		public IActionResult Services()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult Packages(int? page )
		{
			int pageNumber = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 8;
			var listTour = tour.Tours.AsNoTracking().OrderBy(x => x.TenTour);
			PagedList<Tour> lst = new PagedList<Tour>(listTour, pageNumber, pageSize);
			return View(lst);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}