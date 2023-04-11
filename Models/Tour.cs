using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class Tour
{
    public int MaTour { get; set; }

    public int? MaNv { get; set; }

    public string DiaDiem { get; set; } = null!;

    public string TenTour { get; set; } = null!;

    public string ChiTietLt { get; set; } = null!;

    public DateTime NgayBd { get; set; }

    public DateTime NgayKt { get; set; }

    public string AnhTour { get; set; } = null!;

    public decimal? Gia { get; set; }

    public int? Active { get; set; }

    public int? IsDeleted { get; set; }

    public string? NoiKhoiHanh { get; set; }

    public int? Sltcl { get; set; }

    public int? MaQg { get; set; }

    public virtual ICollection<Cttour> Cttours { get; } = new List<Cttour>();

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual TquocGium? MaQgNavigation { get; set; }
}
