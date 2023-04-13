using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Repository
{
    public class DiaDiem:IDiaDiem
    {
		private readonly TourManagementContext _context;

		public DiaDiem(TourManagementContext context)
		{
			_context = context;
		}

		public TquocGium Add(TquocGium MaQg)
		{
			_context.TquocGia.Add(MaQg);
			_context.SaveChanges();
			return MaQg;
		}

		public TquocGium Delete(TquocGium maNuoc)
		{
			throw new NotImplementedException();
		}

        public TquocGium Delete(int MaQg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TquocGium> GetAllQuocGia()
        {
            return _context.TquocGia;
        }

        public TquocGium GetQuocGia(int MaQg)
        {
            return _context.TquocGia.Find(MaQg);
        }

  
		public TquocGium Update(TquocGium MaQg)
		{
			_context.Update(MaQg);
			_context.SaveChanges();
			return MaQg;
		}
	}
}
