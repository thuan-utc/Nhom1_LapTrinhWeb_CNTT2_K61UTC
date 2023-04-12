using Microsoft.AspNetCore.Mvc;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models.TourModels;
using System.Numerics;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TourCustomerAPIController : Controller
	{

		TourManagementContext db = new TourManagementContext();
		[HttpGet]
		public IEnumerable<TourCustomer> GetAllCauthus()
		{
			var tourCustomers = (from p in db.Tours
						  select new TourCustomer
						  {
							  MaTour = p.MaTour,
							  TenTour = p.TenTour,
							  DiaDiem = p.DiaDiem,
							  ChiTietLt = p.ChiTietLt,
							  NgayBd= p.NgayBd,
							  NgayKt= p.NgayKt,
							  Gia=p.Gia,
							  AnhTour = p.AnhTour
						  }).ToList();
			return tourCustomers;
		}
		[HttpGet("{MaQg}")]
		public IEnumerable<TourCustomer> GetTourByNational(int MaQgia)
		{
			var tourCustomers = (from p in db.Tours
						  where p.MaQg == MaQgia
						  select new TourCustomer
						  {
							  MaTour = p.MaTour,
							  TenTour = p.TenTour,
							  DiaDiem = p.DiaDiem,
							  ChiTietLt = p.ChiTietLt,
							  NgayBd = p.NgayBd,
							  NgayKt = p.NgayKt,
							  Gia = p.Gia,
							  AnhTour = p.AnhTour
						  }).ToList();
			return tourCustomers;
		}
	}
}
