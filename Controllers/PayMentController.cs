using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopAoQuan.Models.Authentication;
using ShopAoQuan.Helpers;
using ShopAoQuan.Models;


namespace ShopAoQuan.Controllers
{
    public class PayMentController : Controller
    {
        private readonly QlshopAoQuanContext _context;

        public PayMentController(QlshopAoQuanContext context)
        {
            _context = context;

        }

        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }

        [HttpGet]
        
        public IActionResult Index(string returnUrl = null)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("MaKhanhHang");
            PayMent model = new PayMent();
            if (taikhoanID != null)
            {
                var khachhang = _context.TKhachHangs.AsNoTracking().SingleOrDefault(x => x.MaKhanhHang == taikhoanID);
                model.MaKhanhHang = khachhang.MaKhanhHang;
                model.FullName = khachhang.TenKhachHang;
                model.Note = khachhang.GhiChu;
                model.Phone = khachhang.SoDienThoai;
                model.Address = khachhang.DiaChi;
            }

            ViewBag.GioHang = cart;
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(PayMent muaHang)
        {
            //Lay ra gio hang de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("MaKhanhHang");
            PayMent model = new PayMent();
            if (taikhoanID != null)
            {
                var khachhang = _context.TKhachHangs.AsNoTracking().SingleOrDefault(x => x.MaKhanhHang == taikhoanID);
                model.MaKhanhHang = khachhang.MaKhanhHang;
                model.FullName = khachhang.TenKhachHang;

                model.Phone = khachhang.SoDienThoai;
                model.Address = khachhang.DiaChi;


                khachhang.DiaChi = muaHang.Address;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //Khoi tao don hang
                    THoaDonBan donhang = new THoaDonBan();
                    donhang.MaKhachHang = model.MaKhanhHang;



                    donhang.NgayHoaDon = DateTime.Now;
                    donhang.TransactStatusId = 1;//Don hang moi


                    donhang.TongTienHd = Convert.ToInt32(cart.Sum(x => x.ThanhTien));
                    _context.Add(donhang);
                    _context.SaveChanges();
                    //tao danh sach don hang

                    foreach (var item in cart)
                    {
                        TChiTietHdb orderDetail = new TChiTietHdb();
                        orderDetail.MaHoaDon = donhang.MaHoaDon;
                        orderDetail.MaChiTietSp = item.MaHh;
                        orderDetail.SoLuongBan = item.SoLuong;
                        orderDetail.DonGiaBan = donhang.TongTienHd;


                        _context.Add(orderDetail);
                    }
                    _context.SaveChanges();
                    //clear gio hang
                    HttpContext.Session.Remove("GioHang");
                    //Xuat thong bao
                    TempData["Message"] = "Sản phẩm đã được xóa";

                    //cap nhat thong tin khach hang
                    return RedirectToAction("Success");


                }
            }
            catch
            {

                ViewBag.GioHang = cart;
                return View(model);
            }

            ViewBag.GioHang = cart;
            return View(model);
        }
        [Route("dat-hang-thanh-cong.html", Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("MaKhanhHang");
                if (string.IsNullOrEmpty(taikhoanID))
                {
                    return RedirectToAction("Login", "Accounts", new { returnUrl = "/dat-hang-thanh-cong.html" });
                }
                var khachhang = _context.TKhachHangs.AsNoTracking().SingleOrDefault(x => x.MaKhanhHang == taikhoanID);
                var donhang = _context.THoaDonBans
                    .Where(x => x.MaHoaDon == Convert.ToString(taikhoanID))
                    .OrderByDescending(x => x.NgayHoaDon)
                    .FirstOrDefault();
                MuaHangSuccessVM successVM = new MuaHangSuccessVM();
                successVM.FullName = khachhang.TenKhachHang;
                successVM.DonHangID = donhang.MaHoaDon;
                successVM.Phone = khachhang.SoDienThoai;
                successVM.Address = khachhang.DiaChi;
               
                return View(successVM);
            }
            catch
            {
                return View();
            }
        }
        



    }
}
