using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Repository
{
    public class DiaDiemRepository
    {
		private readonly TourManagementContext _context;

		public DiaDiemRepository(TourManagementContext context)
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

		public IEnumerable<TquocGium> GetAllQuocGium()
		{
			return _context.TquocGia;
		}

		public TquocGium GetQuocGium(string MaQg)
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
