using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public int MaDaiLy { get; set; }

    public int MaTour { get; set; }

    public int MaKh { get; set; }

    public decimal? TongTien { get; set; }

    public int? IsDeleted { get; set; }

    public virtual DaiLy MaDaiLyNavigation { get; set; } = null!;

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual Tour MaTourNavigation { get; set; } = null!;
}
