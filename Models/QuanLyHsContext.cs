using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLY_HOCSINH.Models;

public partial class QuanLyHsContext : DbContext
{
    public QuanLyHsContext()
    {
    }

    public QuanLyHsContext(DbContextOptions<QuanLyHsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiemDanh> DiemDanhs { get; set; }

    public virtual DbSet<GiaoVien> GiaoViens { get; set; }

    public virtual DbSet<GnSoDauBai> GnSoDauBais { get; set; }

    public virtual DbSet<HocSinh> HocSinhs { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<XepLop> XepLops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TTLA;Database=QUAN_LY_HS;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiemDanh>(entity =>
        {
            entity.HasKey(e => e.DiemDanhId).HasName("PK_DIEM_DANH_1");

            entity.ToTable("DIEM_DANH");

            entity.Property(e => e.DiemDanhId).HasColumnName("DIEM_DANH_ID");
            entity.Property(e => e.HsId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("HS_ID");
            entity.Property(e => e.LopId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOP_ID");
            entity.Property(e => e.Ngay).HasColumnName("NGAY");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasColumnName("TRANG_THAI");

            entity.HasOne(d => d.Hs).WithMany(p => p.DiemDanhs)
                .HasForeignKey(d => d.HsId)
                .HasConstraintName("FK_DIEM_DANH_HOC_SINH1");

            entity.HasOne(d => d.Lop).WithMany(p => p.DiemDanhs)
                .HasForeignKey(d => d.LopId)
                .HasConstraintName("FK_DIEM_DANH_LOP_HOC1");
        });

        modelBuilder.Entity<GiaoVien>(entity =>
        {
            entity.HasKey(e => e.GvId);

            entity.ToTable("GIAO_VIEN");

            entity.Property(e => e.GvId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GV_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.HoTen)
                .HasMaxLength(50)
                .HasColumnName("HO_TEN");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("MAT_KHAU");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TAI_KHOAN");
        });

        modelBuilder.Entity<GnSoDauBai>(entity =>
        {
            entity.HasKey(e => e.GnId);

            entity.ToTable("GN_SO_DAU_BAI");

            entity.Property(e => e.GnId).HasColumnName("GN_ID");
            entity.Property(e => e.LopId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOP_ID");
            entity.Property(e => e.Ngay).HasColumnName("NGAY");
            entity.Property(e => e.Noidung)
                .HasMaxLength(250)
                .HasColumnName("NOIDUNG");

            entity.HasOne(d => d.Lop).WithMany(p => p.GnSoDauBais)
                .HasForeignKey(d => d.LopId)
                .HasConstraintName("FK_GN_SO_DAU_BAI_LOP_HOC1");
        });

        modelBuilder.Entity<HocSinh>(entity =>
        {
            entity.HasKey(e => e.HsId);

            entity.ToTable("HOC_SINH");

            entity.Property(e => e.HsId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("HS_ID");
            entity.Property(e => e.Diachi)
                .HasMaxLength(50)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.HoTen)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("HO_TEN");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.LopId);

            entity.ToTable("LOP_HOC");

            entity.Property(e => e.LopId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOP_ID");
            entity.Property(e => e.GvId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GV_ID");
            entity.Property(e => e.TenLop)
                .HasMaxLength(50)
                .HasColumnName("TEN_LOP");

            entity.HasOne(d => d.Gv).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.GvId)
                .HasConstraintName("FK_LOP_HOC_GIAO_VIEN");
        });

        modelBuilder.Entity<XepLop>(entity =>
        {
            entity.HasKey(e => e.XeplopId).HasName("PK_XEP_LOP_1");

            entity.ToTable("XEP_LOP");

            entity.Property(e => e.XeplopId).HasColumnName("XEPLOP_ID");
            entity.Property(e => e.HsId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("HS_ID");
            entity.Property(e => e.LopId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOP_ID");

            entity.HasOne(d => d.Hs).WithMany(p => p.XepLops)
                .HasForeignKey(d => d.HsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XEP_LOP_HOC_SINH1");

            entity.HasOne(d => d.Lop).WithMany(p => p.XepLops)
                .HasForeignKey(d => d.LopId)
                .HasConstraintName("FK_XEP_LOP_LOP_HOC1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
