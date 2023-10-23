using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopAoQuan.Models;

namespace ShopAoQuan
{
    public class mapTaiKhoan
    {
        QlshopAoQuanContext db = new QlshopAoQuanContext();
        //1.Tim Kiem
        public TUser TimKiem(string username,string password )
        {

            var user = db.TUsers.Where(x => x.Username == username &&x.Password==password).ToList();
            if (user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }

        }
        //2 danh sach
        public List<TUser> DanhSach()
        {

            var user = db.TUsers.ToList();
            return user;
           

        }
        //3 Them Moi
        public void ThemTaiKhoan(string username,string password)
        {
            TUser us = new TUser();
            us.Username = username;
            us.Password = password;
            db.TUsers.Add(us);
            db.SaveChanges();
        }
        public bool ThemTaiKhoan(TUser us)
        {
            try
            {
                db.TUsers.Add(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
