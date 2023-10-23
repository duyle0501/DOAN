using ShopAoQuan.Models;

namespace ShopAoQuan.ViewModels
{
    public class HomeCartItem
    {
        public CartItem CartItem { get; set; }
        public TDanhMucSp danhMucSp { get; set; }
        public TChiTietSanPham chiTietSanPham { get; set; }
        public List<TAnhSp> anhSps { get; set; }
    }
}
