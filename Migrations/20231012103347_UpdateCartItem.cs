using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAoQuan.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tAnhSP",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    TenFileAnh = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    ViTri = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAnhSP", x => new { x.MaSP, x.TenFileAnh });
                });

            migrationBuilder.CreateTable(
                name: "tChatLieu",
                columns: table => new
                {
                    MaChatLieu = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    ChatLieu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChatLieu", x => x.MaChatLieu);
                });

            migrationBuilder.CreateTable(
                name: "tKichThuoc",
                columns: table => new
                {
                    MaKichThuoc = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    KichThuoc = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tKichThuoc", x => x.MaKichThuoc);
                });

            migrationBuilder.CreateTable(
                name: "tLoaiSP",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tLoaiSP", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "tMauSac",
                columns: table => new
                {
                    MaMauSac = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    TenMauSac = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tMauSac", x => x.MaMauSac);
                });

            migrationBuilder.CreateTable(
                name: "tUser",
                columns: table => new
                {
                    username = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    LoaiUser = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUser", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "tDanhMucSP",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ThoiGianBaoHanh = table.Column<double>(type: "float", nullable: true),
                    GioiThieuSP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ChietKhau = table.Column<double>(type: "float", nullable: true),
                    MaLoai = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    AnhDaiDien = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    GiaNhoNhat = table.Column<decimal>(type: "money", nullable: true),
                    GiaLonNhat = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDanhMucSP", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_tDanhMucSP_tLoaiSP",
                        column: x => x.MaLoai,
                        principalTable: "tLoaiSP",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateTable(
                name: "tChiTietSanPham",
                columns: table => new
                {
                    MaChiTietSP = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    MaSP = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    MaKichThuoc = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    MaMauSac = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    AnhDaiDien = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    Video = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    DonGiaBan = table.Column<double>(type: "float", nullable: true),
                    GiamGia = table.Column<double>(type: "float", nullable: true),
                    SLTon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChiTietSanPham", x => x.MaChiTietSP);
                    table.ForeignKey(
                        name: "FK_tChiTietSanPham_tKichThuoc",
                        column: x => x.MaKichThuoc,
                        principalTable: "tKichThuoc",
                        principalColumn: "MaKichThuoc");
                    table.ForeignKey(
                        name: "FK_tChiTietSanPham_tMauSac",
                        column: x => x.MaMauSac,
                        principalTable: "tMauSac",
                        principalColumn: "MaMauSac");
                });

            migrationBuilder.CreateTable(
                name: "tKhachHang",
                columns: table => new
                {
                    MaKhanhHang = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    username = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LoaiKhachHang = table.Column<byte>(type: "tinyint", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tKhachHang", x => x.MaKhanhHang);
                    table.ForeignKey(
                        name: "FK_tKhachHang_tUser",
                        column: x => x.username,
                        principalTable: "tUser",
                        principalColumn: "username");
                });

            migrationBuilder.CreateTable(
                name: "tNhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    username = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    TenNhanVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    SoDienThoai = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnhDaiDien = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNhanVien", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_tNhanVien_tUser",
                        column: x => x.username,
                        principalTable: "tUser",
                        principalColumn: "username");
                });

            migrationBuilder.CreateTable(
                name: "tAnhChiTietSP",
                columns: table => new
                {
                    MaChiTietSP = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    TenFileAnh = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    ViTri = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAnhChiTietSP", x => new { x.MaChiTietSP, x.TenFileAnh });
                    table.ForeignKey(
                        name: "FK_tAnhChiTietSP_tChiTietSanPham",
                        column: x => x.MaChiTietSP,
                        principalTable: "tChiTietSanPham",
                        principalColumn: "MaChiTietSP");
                });

            migrationBuilder.CreateTable(
                name: "tChiTietHDB",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    MaChiTietSP = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    SoLuongBan = table.Column<int>(type: "int", nullable: true),
                    DonGiaBan = table.Column<decimal>(type: "money", nullable: true),
                    GiamGia = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChiTietHDB", x => new { x.MaHoaDon, x.MaChiTietSP });
                    table.ForeignKey(
                        name: "FK_tChiTietHDB_tChiTietSanPham",
                        column: x => x.MaChiTietSP,
                        principalTable: "tChiTietSanPham",
                        principalColumn: "MaChiTietSP");
                });

            migrationBuilder.CreateTable(
                name: "tHoaDonBan",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    NgayHoaDon = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaKhachHang = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    MaNhanVien = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    TongTienHD = table.Column<decimal>(type: "money", nullable: true),
                    GiamGiaHD = table.Column<double>(type: "float", nullable: true),
                    PhuongThucThanhToan = table.Column<byte>(type: "tinyint", nullable: true),
                    MaSoThue = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    ThongTinThue = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tHoaDonBan", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_tHoaDonBan_tKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "tKhachHang",
                        principalColumn: "MaKhanhHang");
                    table.ForeignKey(
                        name: "FK_tHoaDonBan_tNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "tNhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietHDB_MaChiTietSP",
                table: "tChiTietHDB",
                column: "MaChiTietSP");

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietSanPham_MaKichThuoc",
                table: "tChiTietSanPham",
                column: "MaKichThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietSanPham_MaMauSac",
                table: "tChiTietSanPham",
                column: "MaMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_tDanhMucSP_MaLoai",
                table: "tDanhMucSP",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_tHoaDonBan_MaKhachHang",
                table: "tHoaDonBan",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_tHoaDonBan_MaNhanVien",
                table: "tHoaDonBan",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_tKhachHang_username",
                table: "tKhachHang",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_tNhanVien_username",
                table: "tNhanVien",
                column: "username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tAnhChiTietSP");

            migrationBuilder.DropTable(
                name: "tAnhSP");

            migrationBuilder.DropTable(
                name: "tChatLieu");

            migrationBuilder.DropTable(
                name: "tChiTietHDB");

            migrationBuilder.DropTable(
                name: "tDanhMucSP");

            migrationBuilder.DropTable(
                name: "tHoaDonBan");

            migrationBuilder.DropTable(
                name: "tChiTietSanPham");

            migrationBuilder.DropTable(
                name: "tLoaiSP");

            migrationBuilder.DropTable(
                name: "tKhachHang");

            migrationBuilder.DropTable(
                name: "tNhanVien");

            migrationBuilder.DropTable(
                name: "tKichThuoc");

            migrationBuilder.DropTable(
                name: "tMauSac");

            migrationBuilder.DropTable(
                name: "tUser");
        }
    }
}
