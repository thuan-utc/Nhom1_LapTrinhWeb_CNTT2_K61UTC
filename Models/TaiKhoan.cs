using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class TaiKhoan
{
    public int Id { get; set; }

    public string Taikhoan1 { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Loai { get; set; } = null!;

    public int? MaDaiLy { get; set; }

    public int? MaKh { get; set; }

    public int? IsDeleted { get; set; }

    public virtual DaiLy? MaDaiLyNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }
}
