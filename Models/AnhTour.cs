using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class AnhTour
{
    public int MaTour { get; set; }

    public string? TenFileAnh { get; set; }

    public string? ViTri { get; set; }

    public virtual Tour MaTourNavigation { get; set; } = null!;
}
