using System;
using System.Collections.Generic;

namespace ShopAoQuan.Models;

public partial class TAnhSp
{
    public string MaSp { get; set; } = null!;

    public string TenFileAnh { get; set; } = null!;

    public short? ViTri { get; set; }
}
