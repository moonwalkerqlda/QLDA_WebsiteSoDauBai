using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class XepLop
{
    public string? LopId { get; set; }

    public string HsId { get; set; } = null!;

    public int XeplopId { get; set; }

    public virtual HocSinh Hs { get; set; } = null!;

    public virtual LopHoc? Lop { get; set; }
}
