namespace ProjectQLTS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        public int IDDonChiTiet { get; set; }

        public int? IDDonHang { get; set; }

        public int? IDTraSua { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
