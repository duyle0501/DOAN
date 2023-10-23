using ShopAoQuan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace ShopAoQuan.Controllers
{
    public class AccessController : Controller
    {
        QlshopAoQuanContext db = new QlshopAoQuanContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName")==null)
            {
                TempData["Message"] = "Vui lòng nhập lại";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    
                    if (u.LoaiUser == 0)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("DangNhapThanhCong", "Home");
                    }
                }
                else
                {
                    TempData["Message"] = "Vui lòng nhập lại";
                }
            }
            return View();
        }
        //Đăng xuất 
       public IActionResult SuaThongtin()
        {
            var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
            var item=u.
            HttpContext.Session.SetString("UserName", u.Username.ToString());
            if(u.LoaiUser==1)
            {
                var thongtin = db.TKhachHang();

            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("login", "Access");
        }
       
    }
}
