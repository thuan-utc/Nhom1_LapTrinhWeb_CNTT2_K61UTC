//using Microsoft.AspNetCore.Mvc;
//using Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Cooperator.Controllers;

//namespace Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Cooperator.ViewComponents
//{
//    public class TourController : Controller
//    {
//        private readonly TourRegistrationContext _context;

//        public TourController(TourRegistrationContext context)
//        {
//            _context = context;
//        }

//        public IActionResult RegisteredCustomers(int tourId)
//        {
//            var registrations = _context.TourRegistrations.Where(r => r.MaTour == tourId).ToList();
//            return View(registrations);
//        }
//    }
//}
