using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public int? MaDaiLy { get; set; }

    public string TenNv { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string ChucVu { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string AnhNv { get; set; } = null!;

    public int? IsDeleted { get; set; }

    public virtual DaiLy? MaDaiLyNavigation { get; set; }

    public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
}
