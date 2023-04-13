namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models.TourModels
{
    public class TourCustomer
    {
		public int MaTour { get; set; }
		public string DiaDiem { get; set; } = null!;

		public string TenTour { get; set; } = null!;
		public string ChiTietLt { get; set; } = null!;
		public DateTime NgayBd { get; set; }

		public DateTime NgayKt { get; set; }

		public string AnhTour { get; set; } = null!;

		public decimal? Gia { get; set; }

		public int? MaQg { get; set; }
	}
}
