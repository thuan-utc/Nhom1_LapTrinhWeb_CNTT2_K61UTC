using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class DaiLy
{
    public int MaDaiLy { get; set; }

    public string TenDaiLy { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public int? IsDeleted { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; } = new List<TaiKhoan>();
}
