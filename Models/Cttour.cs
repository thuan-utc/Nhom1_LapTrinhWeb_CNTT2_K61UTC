using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class Cttour
{
    public int MaCttour { get; set; }

    public int MaTour { get; set; }

    public string ThoiGian { get; set; } = null!;

    public string PhuongTien { get; set; } = null!;

    public string? ĐiemTq { get; set; }

    public string AmThuc { get; set; } = null!;

    public string KhachSan { get; set; } = null!;

    public string DoiTuongTh { get; set; } = null!;

    public string? UuDai { get; set; }
}
