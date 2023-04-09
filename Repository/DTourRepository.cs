//using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

//namespace Nhom1_LapTrinhWeb_CNTT2_K61.Repository
//{
//    public class DTourRepository : IDTourRepository
//    {
//        private readonly TourManagementContext _context;
//        public DTourRepository(TourManagementContext context)
//        {
//            _context = context;
//        }
//        public HoaDon Add(HoaDon hoaDon)
//        {
//            _context.HoaDons.Add(hoaDon);
//            _context.SaveChanges();
//            return hoaDon;
//        }

//        public HoaDon Delete(string mahoaDon)
//        {
//            throw new NotImplementedException();
//        }

//        public HoaDon GetHD(string mahoaDon)
//        {
//            return _context.HoaDons.Find(mahoaDon);
//        }

//        public IEnumerable<HoaDon> GetHD()
//        {
//            return _context.HoaDons;
//        }

//        public HoaDon Update(HoaDon hoaDon)
//        {
//            _context.Update(hoaDon);
//            _context.SaveChanges();
//            return hoaDon;
//        }
//    }
//}
