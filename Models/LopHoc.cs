using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class LopHoc
{
    public string LopId { get; set; } = null!;

    public string? TenLop { get; set; }

    public string? GvId { get; set; }

    public virtual ICollection<DiemDanh> DiemDanhs { get; set; } = new List<DiemDanh>();

    public virtual ICollection<GnSoDauBai> GnSoDauBais { get; set; } = new List<GnSoDauBai>();

    public virtual GiaoVien? Gv { get; set; }

    public virtual ICollection<XepLop> XepLops { get; set; } = new List<XepLop>();
}
