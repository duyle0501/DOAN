using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopAoQuan.Models;
using System.Security.Policy;
using X.PagedList;

namespace ShopAoQuan.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlshopAoQuanContext db = new QlshopAoQuanContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        // DANH MỤC SẢN PHẨM 
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("TimKiemSanPham")]
        
        public IActionResult TimKiemSanPham(string tenSanPham,int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            // Tìm kiếm sản phẩm
            var products = db.TDanhMucSps.Where(
                p => p.TenSp.Contains(tenSanPham) 
            );
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(products, pageNumber, pageSize);

            // Trả về kết quả tìm kiếm
            return View(lst);
        }
        //Thêm sản phẩm vào danh mục sản phẩm
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.Maloai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham);
                db.SaveChanges();
                TempData["Message"] = "Thêm thành công .";
                return RedirectToAction("DanhMucSanPham");
            }
            
            return View(sanPham);
        }
        //SỬA SẢN PHẨM TRONG DANH MỤC SẢN PHẢM 
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.Maloai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp==maSanPham);
            if (anhSanPham.Any()) db.RemoveRange(anhSanPham);
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");

        }
        [Route("chitietsanpham")]
        public IActionResult ChiTietSanPham(int? page)
        {

            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TChiTietSanPhams.AsNoTracking().OrderBy(x => x.MaChiTietSp);
            PagedList<TChiTietSanPham> lst = new PagedList<TChiTietSanPham>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
       
        //Them SAN PHAM CHI TIET
        [Route("ThemSanPhamMoiChiTiet")]
        [HttpGet]
        public IActionResult ThemSanPhamMoiChiTiet()
        {
            ViewBag.MaKichThuoc = new SelectList(db.TKichThuocs.ToList(), "MaKichThuoc", "KichThuoc");
            ViewBag.MaMauSac = new SelectList(db.TMauSacs.ToList(), "MaMauSac", "TenMauSac");
            return View();
        }
        [Route("ThemSanPhamMoiChiTiet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoiChiTiet(TChiTietSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TChiTietSanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham");
            }
            
            return View(sanPham);
        }
        //sua san pham chi tiet
        [Route("SuaSanPhamChiTiet")]
        [HttpGet]
        public IActionResult SuaSanPhamChiTiet(string maSanPham)
        {
            ViewBag.MaKichThuoc = new SelectList(db.TKichThuocs.ToList(), "MaKichThuoc", "KichThuoc");
            ViewBag.MaMauSac = new SelectList(db.TMauSacs.ToList(), "MaMauSac", "TenMauSac");
            var sanPham = db.TChiTietSanPhams.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPhamChiTiet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPhamChiTiet(TChiTietSanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChiTietSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        //xÓA SẢN PHẢM CHI TIẾT 
        [Route("XoaSanPhamChiTiet")]
        [HttpGet]
        public IActionResult XoaSanPhamChiTiet(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TAnhChiTietSps.Where(x => x.MaChiTietSp == maSanPham).ToList();
            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("ChiTietSanPham", "HomeAdmin");
            }
                var anhSanPham = db.TChiTietHdbs.Where(x => x.MaChiTietSp == maSanPham);
                if (anhSanPham.Any()) db.RemoveRange(anhSanPham);
            db.Remove(db.TChiTietSanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("ChiTietSanPham", "HomeAdmin");

        }
        //ĐĂNG KÝ NGƯỜI DÙNG
        [Route("DangKyTaiKhoan")]
        [HttpGet]
        public IActionResult DangKyTaiKhoan()
        {
            
            return View();
        }
        [Route("DangKyTaiKhoan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKyTaiKhoan(TUser user)
        {
            user.Username = Request.Form["username"];
            user.Password = Request.Form["password"];
            if (user.Username == null || user.Username.Length == 0)
            {
                return BadRequest("Tên người dùng không được để trống.");
            }

            if (user.Password == null || user.Password.Length == 0)
            {
                TempData["1"] = "Mật khẩu không được để trống.";

                // Hiển thị trang đăng ký cho người dùng
                return View(user);
               
            }

            if (user.Password != Request.Form["confirm-password"])
            {
                TempData["1"] = "Mật khẩu xác nhận không trùng khớp nhau ";

                // Hiển thị trang đăng ký cho người dùng
                return View(user);
            }

            if (ModelState.IsValid)
            {
                // Tạo một truy vấn SQL để kiểm tra xem tên người dùng đã tồn tại hay chưa
                var query = db.TUsers.Where(x => x.Username == user.Username);
                user.LoaiUser = 1;
                // Kiểm tra xem kết quả của truy vấn có rỗng hay không
                if (query.Count() > 0)
                {
                    // Thêm lỗi vào trạng thái mô hình
                    TempData["1"] = "Tên tài khoản đã có người dùng ";

                    // Hiển thị trang đăng ký cho người dùng
                    return View(user);
                }

                // Thêm một bản ghi mới vào bảng TUsers
                db.TUsers.Add(user);
                db.SaveChanges();

                // Chuyển hướng người dùng đến trang chủ
                return RedirectToAction("login", "Access");
            }
            return View(user);

        }
        //USER
        //DANH MỤC TÀI KHOẢN KHÁCH HÀNG 
        [Route("danhmuctaikhoan")]
        public IActionResult DanhMucKhachHang(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TKhachHangs.AsNoTracking().OrderBy(x => x.Username);
            PagedList<TKhachHang> lst = new PagedList<TKhachHang>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        
       
        //SỬA THÔNG TIN KHÁCH HÀNG 
        [Route("SuaKhachHang")]
        [HttpGet]
        public IActionResult SuaKhachHang(string khachhang)
        {
            ViewBag.Username = new SelectList(db.TUsers.Select(u => u.Username));
            var kh = db.TKhachHangs.Find(khachhang);
            return View(kh);
        }
        [Route("SuaKhachHang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaKhachHang(TKhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucKhachHang", "HomeAdmin");
            }
            return View(kh);
        }
        //Xoa thoong tin khach hang
        [Route("Xoakhachhang")]
        [HttpGet]
        public IActionResult XoaKhachHang(string khachhang)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.THoaDonBans.Where(x => x.MaKhachHang == khachhang).ToList();

            // Kiểm tra xem khách hàng có tồn tại trong cơ sở dữ liệu hay không
            if (!db.TKhachHangs.Any(x => x.MaKhanhHang == khachhang))
            {
                TempData["Message"] = "Khách hàng không tồn tại";
                return RedirectToAction("DanhMucKhachHang", "HomeAdmin");
            }

            // Xóa khách hàng khỏi cơ sở dữ liệu
            try
            {
                db.Remove(db.TKhachHangs.Find(khachhang));
                db.SaveChanges();

                TempData["Message"] = "Khách hàng đã được xóa";
                return RedirectToAction("DanhMucKhachHang", "HomeAdmin");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Có lỗi xảy ra khi xóa khách hàng: " + ex.Message;
                return RedirectToAction("DanhMucKhachHang", "HomeAdmin");
            }
        }
        //DANH MỤC TÀI KHOẢN NHÂN VIÊN  
        [Route("danhmuctaikhoanNhanVien")]
        public IActionResult DanhMucNhanVien(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TNhanViens.AsNoTracking().OrderBy(x => x.Username);
            PagedList<TNhanVien> lst = new PagedList<TNhanVien>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        //Thêm khach hang
        [Route("ThemNhanVien")]
        [HttpGet]
        public IActionResult ThemNhanVien()
        {
            ViewBag.Username = new SelectList(db.TUsers.Select(u => u.Username));
            return View();
        }
        [Route("ThemNhanVien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVien(TNhanVien vien)
        {
            if (ModelState.IsValid)
            {
                db.TNhanViens.Add(vien);
                db.SaveChanges();
                return RedirectToAction("DanhMucNhanVien");
            }
            return View(vien);
        }
        //SỬA THÔNG TIN Nhân viên 
        [Route("SuaNhanVien")]
        [HttpGet]
        public IActionResult SuaNhanVien(string khachhang)
        {
            ViewBag.Username = new SelectList(db.TUsers.Select(u => u.Username));
            var kh = db.TNhanViens.Find(khachhang);
            return View(kh);
        }
        [Route("SuaKhachHang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(TNhanVien kh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucNhanVien", "HomeAdmin");
            }
            return View(kh);
        }
        //Xoa thông tin nhân viên 
        [Route("Xoanhanvien")]
        [HttpGet]
        public IActionResult XoaNhanVien(string khachhang)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.THoaDonBans.Where(x => x.MaNhanVien == khachhang).ToList();

            // Kiểm tra xem khách hàng có tồn tại trong cơ sở dữ liệu hay không
            if (!db.TNhanViens.Any(x => x.MaNhanVien == khachhang))
            {
                TempData["Message"] = "Khách hàng không tồn tại";
                return RedirectToAction("DanhMucNhanVien", "HomeAdmin");
            }

            // Xóa khách hàng khỏi cơ sở dữ liệu
            try
            {
                db.Remove(db.TNhanViens.Find(khachhang));
                db.SaveChanges();

                TempData["Message"] = "Khách hàng đã được xóa";
                return RedirectToAction("DanhMucNhanVien", "HomeAdmin");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Có lỗi xảy ra khi xóa khách hàng: " + ex.Message;
                return RedirectToAction("DanhMucNhanVien", "HomeAdmin");
            }
        }

    }
}
