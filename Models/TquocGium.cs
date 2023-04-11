using System;
using System.Collections.Generic;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class TquocGium
{
    public int MaQg { get; set; }

    public string TenQg { get; set; } = null!;

    public virtual ICollection<Tour> Tours { get; } = new List<Tour>();
}
