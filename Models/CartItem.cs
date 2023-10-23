using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAoQuan.Models
{
    public class CartItem
    {
        public string MaHh { get; set; }
        public string? TenHH { get; set; }
        public string Hinh { get; set; }
        public decimal? DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal? ThanhTien => SoLuong * DonGia;

        TChiTietSanPham chiTiet;
        

        decimal? total = 0;

        public decimal? TinhThanhTien()
        {
            if (DonGia == null)
            {
                return 0;
            }

            return SoLuong * DonGia;
        }








    }
}