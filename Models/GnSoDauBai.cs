using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class GnSoDauBai
{
    public DateOnly? Ngay { get; set; }

    public string? LopId { get; set; }

    public string? Noidung { get; set; }

    public int GnId { get; set; }

    public virtual LopHoc? Lop { get; set; }
}
