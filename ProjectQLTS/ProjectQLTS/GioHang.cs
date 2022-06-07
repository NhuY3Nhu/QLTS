namespace ProjectQLTS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        public int IDGioHang { get; set; }

        public int? IDDonHang { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
