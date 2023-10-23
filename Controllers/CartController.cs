using Microsoft.AspNetCore.Mvc;
using ShopAoQuan.Helpers;
using ShopAoQuan.Models;
using ShopAoQuan.Models.Authentication;
using System;

namespace ShopAoQuan.Controllers
{
    public class CartController : Controller
    {
        private readonly QlshopAoQuanContext _context;

        public CartController(QlshopAoQuanContext context)
        {
            _context = context;
        }
        
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }
        [Authentication]
        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View(Carts);
        }
        
        public IActionResult AddToCart(string id, int SoLuong, string type = "Normal")
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaHh == id);

            if (item == null)//chưa có
            {
                var hangHoa = _context.TDanhMucSps.SingleOrDefault(p => p.MaSp == id);
                item = new CartItem
                {
                    MaHh = id,
                    TenHH = hangHoa.TenSp,
                    DonGia = hangHoa.GiaLonNhat.Value,
                    SoLuong = SoLuong,
                    Hinh = hangHoa.AnhDaiDien

                };

                myCart.Add(item);
            }
            else
            {
                item.SoLuong += SoLuong;
            }
            HttpContext.Session.Set("GioHang", myCart);
            if (type == "ajax")
            {
                return Json(new
                {
                    SoLuong = Carts.Sum(c => c.SoLuong),
                });
            }

            return RedirectToAction("Index");
        }
        [Route("api/cart/update")]
        public IActionResult UpdateCart(string productID, int? amount)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if (cart != null)
                {
                    List<CartItem> gioHang = Carts;
                    CartItem item = gioHang.SingleOrDefault(p => p.MaHh == productID);
                    if (item != null && amount.HasValue) // da co -> cap nhat so luong
                    {
                        item.SoLuong = amount.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/remove")]
        public ActionResult Remove(string productID)
        {

            try
            {
                List<CartItem> gioHang = Carts;
                CartItem item = gioHang.SingleOrDefault(p => p.MaHh == productID);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                //luu lai session
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
    }

    }

