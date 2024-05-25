using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class HocSinh
{
    public string HsId { get; set; } = null!;

    public string? HoTen { get; set; }


    public virtual ICollection<XepLop> XepLops { get; set; } = new List<XepLop>();
}
