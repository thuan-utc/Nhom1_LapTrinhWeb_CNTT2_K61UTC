using Microsoft.AspNetCore.Mvc;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
namespace Nhom1_LapTrinhWeb_CNTT2_K61.Areas.Cooperator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        TourManagementContext db = new TourManagementContext();
        [HttpGet]
        public IEnumerable<KhachHang> GetAllProducts()
        {
            return db.KhachHangs;
        }
        [HttpGet("{makh}")]
        public IEnumerable<KhachHang> getKhByHd(int makh)
        {
            var khachs = (from c in db.KhachHangs
                           join t in db.HoaDons on c.MaKh equals t.MaKh
                           join q in db.Cthds on t.MaHd equals q.MaHd
                           where t.MaKh == makh
                           select c) ;
            return khachs;
        }

    }
}
