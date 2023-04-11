using Microsoft.AspNetCore.Mvc;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Controllers
{
	public class AccessController : Controller
	{
		TourManagementContext db = new TourManagementContext();

		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetString("UserName") == null)
			{
				return View();
			}
			return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public IActionResult Login(TaiKhoan user)
		{
			if (HttpContext.Session.GetString("UserName") == null)
			{
				var obj = db.TaiKhoans.Where(x => x.Taikhoan1 == user.Taikhoan1 && x.Matkhau == user.Matkhau).FirstOrDefault();
				if (obj != null)
				{
					HttpContext.Session.SetString("UserName", obj.Taikhoan1.ToString());
					switch (obj.Loai)
					{
						case "admin":
							return RedirectToAction("Index", "HomeAdmin");
						case "agency":
							return RedirectToAction("Index", "HomeCooperator");
						case "customer":
							return RedirectToAction("Index", "Home");
						default:
							return View();
					}
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("UserName");
			return RedirectToAction("Login", "Access");
		}
	}
}
