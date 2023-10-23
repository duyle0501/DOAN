﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopAoQuan.Models;

#nullable disable

namespace ShopAoQuan.Migrations
{
    [DbContext(typeof(QlshopAoQuanContext))]
    partial class QlshopAoQuanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopAoQuan.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TAnhChiTietSp", b =>
                {
                    b.Property<string>("MaChiTietSp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .HasColumnName("MaChiTietSP")
                        .IsFixedLength();

                    b.Property<string>("TenFileAnh")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.Property<short?>("ViTri")
                        .HasColumnType("smallint");

                    b.HasKey("MaChiTietSp", "TenFileAnh");

                    b.ToTable("tAnhChiTietSP", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TAnhSp", b =>
                {
                    b.Property<string>("MaSp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .HasColumnName("MaSP")
                        .IsFixedLength();

                    b.Property<string>("TenFileAnh")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.Property<short?>("ViTri")
                        .HasColumnType("smallint");

                    b.HasKey("MaSp", "TenFileAnh");

                    b.ToTable("tAnhSP", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TChatLieu", b =>
                {
                    b.Property<string>("MaChatLieu")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("ChatLieu")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaChatLieu");

                    b.ToTable("tChatLieu", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TChiTietHdb", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("MaChiTietSp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .HasColumnName("MaChiTietSP")
                        .IsFixedLength();

                    b.Property<decimal?>("DonGiaBan")
                        .HasColumnType("money");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("GiamGia")
                        .HasColumnType("float");

                    b.Property<int?>("SoLuongBan")
                        .HasColumnType("int");

                    b.HasKey("MaHoaDon", "MaChiTietSp");

                    b.HasIndex("MaChiTietSp");

                    b.ToTable("tChiTietHDB", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TChiTietSanPham", b =>
                {
                    b.Property<string>("MaChiTietSp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .HasColumnName("MaChiTietSP")
                        .IsFixedLength();

                    b.Property<string>("AnhDaiDien")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.Property<double?>("DonGiaBan")
                        .HasColumnType("float");

                    b.Property<double?>("GiamGia")
                        .HasColumnType("float");

                    b.Property<string>("MaKichThuoc")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("MaMauSac")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("MaSp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .HasColumnName("MaSP")
                        .IsFixedLength();

                    b.Property<int?>("Slton")
                        .HasColumnType("int")
                        .HasColumnName("SLTon");

                    b.Property<string>("Video")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.HasKey("MaChiTietSp");

                    b.HasIndex("MaKichThuoc");

                    b.HasIndex("MaMauSac");

                    b.ToTable("tChiTietSanPham", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TDanhMucSp", b =>
                {
                    b.Property<string>("MaSp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .HasColumnName("MaSP")
                        .IsFixedLength();

                    b.Property<string>("AnhDaiDien")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.Property<double?>("ChietKhau")
                        .HasColumnType("float");

                    b.Property<decimal?>("GiaLonNhat")
                        .HasColumnType("money");

                    b.Property<decimal?>("GiaNhoNhat")
                        .HasColumnType("money");

                    b.Property<string>("GioiThieuSp")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("GioiThieuSP");

                    b.Property<string>("MaLoai")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("TenSp")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("TenSP");

                    b.Property<double?>("ThoiGianBaoHanh")
                        .HasColumnType("float");

                    b.HasKey("MaSp");

                    b.HasIndex("MaLoai");

                    b.ToTable("tDanhMucSP", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.THoaDonBan", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("GhiChu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("GiamGiaHd")
                        .HasColumnType("float")
                        .HasColumnName("GiamGiaHD");

                    b.Property<string>("MaKhachHang")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("MaNhanVien")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("MaSoThue")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.Property<DateTime?>("NgayHoaDon")
                        .HasColumnType("datetime");

                    b.Property<byte?>("PhuongThucThanhToan")
                        .HasColumnType("tinyint");

                    b.Property<string>("ThongTinThue")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal?>("TongTienHd")
                        .HasColumnType("money")
                        .HasColumnName("TongTienHD");

                    b.Property<int>("TransactStatusId")
                        .HasColumnType("int");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("tHoaDonBan", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TKhachHang", b =>
                {
                    b.Property<string>("MaKhanhHang")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("DiaChi")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte?>("LoaiKhachHang")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .IsFixedLength();

                    b.Property<string>("TenKhachHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.HasKey("MaKhanhHang");

                    b.HasIndex("Username");

                    b.ToTable("tKhachHang", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TKichThuoc", b =>
                {
                    b.Property<string>("MaKichThuoc")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("KichThuoc")
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .IsFixedLength();

                    b.HasKey("MaKichThuoc");

                    b.ToTable("tKichThuoc", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TLoaiSp", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("Loai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaLoai");

                    b.ToTable("tLoaiSP", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TMauSac", b =>
                {
                    b.Property<string>("MaMauSac")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("TenMauSac")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaMauSac");

                    b.ToTable("tMauSac", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TNhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.Property<string>("AnhDaiDien")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .IsFixedLength();

                    b.Property<string>("ChucVu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .IsFixedLength();

                    b.Property<string>("TenNhanVien")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.HasKey("MaNhanVien");

                    b.HasIndex("Username");

                    b.ToTable("tNhanVien", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TUser", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("char(100)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.Property<byte?>("LoaiUser")
                        .HasColumnType("tinyint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("password")
                        .IsFixedLength();

                    b.HasKey("Username");

                    b.ToTable("tUser", (string)null);
                });

            modelBuilder.Entity("ShopAoQuan.Models.TAnhChiTietSp", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TChiTietSanPham", "MaChiTietSpNavigation")
                        .WithMany("TAnhChiTietSps")
                        .HasForeignKey("MaChiTietSp")
                        .IsRequired()
                        .HasConstraintName("FK_tAnhChiTietSP_tChiTietSanPham");

                    b.Navigation("MaChiTietSpNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TChiTietHdb", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TChiTietSanPham", "MaChiTietSpNavigation")
                        .WithMany("TChiTietHdbs")
                        .HasForeignKey("MaChiTietSp")
                        .IsRequired()
                        .HasConstraintName("FK_tChiTietHDB_tChiTietSanPham");

                    b.Navigation("MaChiTietSpNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TChiTietSanPham", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TKichThuoc", "MaKichThuocNavigation")
                        .WithMany("TChiTietSanPhams")
                        .HasForeignKey("MaKichThuoc")
                        .HasConstraintName("FK_tChiTietSanPham_tKichThuoc");

                    b.HasOne("ShopAoQuan.Models.TMauSac", "MaMauSacNavigation")
                        .WithMany("TChiTietSanPhams")
                        .HasForeignKey("MaMauSac")
                        .HasConstraintName("FK_tChiTietSanPham_tMauSac");

                    b.Navigation("MaKichThuocNavigation");

                    b.Navigation("MaMauSacNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TDanhMucSp", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TLoaiSp", "MaLoaiNavigation")
                        .WithMany("TDanhMucSps")
                        .HasForeignKey("MaLoai")
                        .HasConstraintName("FK_tDanhMucSP_tLoaiSP");

                    b.Navigation("MaLoaiNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.THoaDonBan", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TKhachHang", "MaKhachHangNavigation")
                        .WithMany("THoaDonBans")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK_tHoaDonBan_tKhachHang");

                    b.HasOne("ShopAoQuan.Models.TNhanVien", "MaNhanVienNavigation")
                        .WithMany("THoaDonBans")
                        .HasForeignKey("MaNhanVien")
                        .HasConstraintName("FK_tHoaDonBan_tNhanVien");

                    b.Navigation("MaKhachHangNavigation");

                    b.Navigation("MaNhanVienNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TKhachHang", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TUser", "UsernameNavigation")
                        .WithMany("TKhachHangs")
                        .HasForeignKey("Username")
                        .HasConstraintName("FK_tKhachHang_tUser");

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TNhanVien", b =>
                {
                    b.HasOne("ShopAoQuan.Models.TUser", "UsernameNavigation")
                        .WithMany("TNhanViens")
                        .HasForeignKey("Username")
                        .HasConstraintName("FK_tNhanVien_tUser");

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TChiTietSanPham", b =>
                {
                    b.Navigation("TAnhChiTietSps");

                    b.Navigation("TChiTietHdbs");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TKhachHang", b =>
                {
                    b.Navigation("THoaDonBans");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TKichThuoc", b =>
                {
                    b.Navigation("TChiTietSanPhams");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TLoaiSp", b =>
                {
                    b.Navigation("TDanhMucSps");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TMauSac", b =>
                {
                    b.Navigation("TChiTietSanPhams");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TNhanVien", b =>
                {
                    b.Navigation("THoaDonBans");
                });

            modelBuilder.Entity("ShopAoQuan.Models.TUser", b =>
                {
                    b.Navigation("TKhachHangs");

                    b.Navigation("TNhanViens");
                });
#pragma warning restore 612, 618
        }
    }
}
