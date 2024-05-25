﻿using System;
using System.Collections.Generic;

namespace QLY_HOCSINH.Models;

public partial class XepLop
{
    public string? LopId { get; set; }

    public string? HsId { get; set; }

    public int XeplopId { get; set; }

    public virtual HocSinh? Hs { get; set; }

    public virtual LopHoc? Lop { get; set; }
}