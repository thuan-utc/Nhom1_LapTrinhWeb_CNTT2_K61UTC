using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Models;

public partial class TourManagementContext : DbContext
{
    public TourManagementContext()
    {
    }

    public TourManagementContext(DbContextOptions<TourManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cthd> Cthds { get; set; }

    public virtual DbSet<DaiLy> DaiLies { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TourManagement.mssql.somee.com;Initial Catalog=TourManagement;User ID=thuanngungu_SQLLogin_1;Password=tlsxvr1d4e;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cthd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CTHD");

            entity.Property(e => e.Gia).HasColumnType("money");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaCthd)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaCTHD");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaHdNavigation).WithMany()
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CTHD_HoaDon");
        });

        modelBuilder.Entity<DaiLy>(entity =>
        {
            entity.HasKey(e => e.MaDaiLy).HasName("PK__DaiLy__069B00B3F1208175");

            entity.ToTable("DaiLy");

            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.TenDaiLy).HasMaxLength(30);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E041473A4F");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.MaDaiLyNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaDaiLy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HoaDon_DaiLy");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HoaDon_KhachHang");

            entity.HasOne(d => d.MaTourNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaTour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HoaDon_Tour");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1EF4D36ACF");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.AnhKh)
                .HasMaxLength(100)
                .HasColumnName("AnhKH");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.SoCmnd)
                .HasMaxLength(20)
                .HasColumnName("SoCMND");
            entity.Property(e => e.TenKh)
                .HasMaxLength(30)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A4DB126CB");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.AnhNv)
                .HasMaxLength(300)
                .HasColumnName("AnhNV");
            entity.Property(e => e.ChucVu).HasMaxLength(20);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(30)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.MaDaiLyNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaDaiLy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_NhanVien_DaiLy");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3213E83FC0941D66");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Loai)
                .HasMaxLength(20)
                .HasColumnName("loai");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(30)
                .HasColumnName("matkhau");
            entity.Property(e => e.Taikhoan1)
                .HasMaxLength(30)
                .HasColumnName("taikhoan");

            entity.HasOne(d => d.MaDaiLyNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaDaiLy)
                .HasConstraintName("fk_TaiKhoan_DaiLy");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("fk_TaiKhoan_KhachHang");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.MaTour).HasName("PK__Tour__4E5557DE22B0F4BA");

            entity.ToTable("Tour");

            entity.Property(e => e.Active).HasDefaultValueSql("((0))");
            entity.Property(e => e.AnhTour).HasMaxLength(300);
            entity.Property(e => e.ChiTietLt)
                .HasMaxLength(500)
                .HasColumnName("ChiTietLT");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayBd)
                .HasColumnType("datetime")
                .HasColumnName("NgayBD");
            entity.Property(e => e.NgayKt)
                .HasColumnType("datetime")
                .HasColumnName("NgayKT");
            entity.Property(e => e.TenTour).HasMaxLength(30);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_NhanVien");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
