using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class DiemDanh
{
    public int DiemDanhId { get; set; }

    public string? LopId { get; set; }

    public DateOnly? Ngay { get; set; }

    public string? HsId { get; set; }

    public string? TrangThai { get; set; }

    public virtual HocSinh? Hs { get; set; }

    public virtual LopHoc? Lop { get; set; }
}
