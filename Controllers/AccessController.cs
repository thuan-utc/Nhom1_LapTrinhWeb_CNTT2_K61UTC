using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using System.Data.Common;

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
							return RedirectToAction("Index", "HomeCustomer");
						default:
							return View();
					}
				}
			}
			ModelState.AddModelError(string.Empty, "Invalid username or password");
			return View(user);
		}
		[HttpGet]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("UserName");
			return RedirectToAction("Login", "Access");
		}

		//Dang ky
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SignUp(TaiKhoan user)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra xem tài khoản đã tồn tại chưa
				var u = db.TaiKhoans.Where(x => x.Taikhoan1.Equals(user.Taikhoan1)).FirstOrDefault();
				if (u != null)
				{
					ModelState.AddModelError("TaiKhoan", "Tài khoản đã được sử dụng");
					return View(user);
				}

				// Thêm người dùng mới vào cơ sở dữ liệu
				db.TaiKhoans.Add(user);
				db.SaveChanges();

				// Đăng nhập người dùng mới đăng ký
				HttpContext.Session.SetString("TaiKhoan", user.Taikhoan1);
				return RedirectToAction("Login", "Access");
			}

			return View(user);
		}

	}
}
