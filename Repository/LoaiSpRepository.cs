using ShopAoQuan.Models;
namespace ShopAoQuan.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QlshopAoQuanContext _context;
        public LoaiSpRepository(QlshopAoQuanContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;

        }
        public TLoaiSp Delete(string maloaisp)
        {
            throw new NotSupportedException();
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }



        public TLoaiSp GetLoaiSp(string maLoaiSp)
        {
            return _context.TLoaiSps.Find(maLoaiSp);
        }



        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }
    }
}
