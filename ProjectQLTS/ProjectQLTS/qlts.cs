using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjectQLTS
{
    public partial class qlts : DbContext
    {
        public qlts()
            : base("name=qlts")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(e => e.LoaiTraSua)
                .IsFixedLength();

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.MatKhau)
                .IsFixedLength();
        }
    }
}
