namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models
{
    public class Product
    {
        public int MaKh { get; set; }
        public int MaTour { get; set; }
        public string? TenKh { get; set; }
        public string? Sdt { get; set; }
        public virtual KhachHang MaKhNavigation { get; set; } = null!;
        public virtual Tour MaTourNavigation { get; set; } = null!;
    }
}
