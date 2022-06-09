namespace ProjectQLTS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int IDThanhVien { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin!")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin!")]
        public string DiaChi { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin!")]
        public string SDT { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Vui lòng nhập đầy đủ thông tin!")]
        public string MatKhau { get; set; }

        public int? IDQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
