using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class GiaoVien
{
    public string GvId { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
