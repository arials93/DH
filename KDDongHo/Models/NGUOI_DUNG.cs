//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDDongHo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NGUOI_DUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOI_DUNG()
        {
            this.BAI_VIET = new HashSet<BAI_VIET>();
            this.HOAT_DONG = new HashSet<HOAT_DONG>();
            this.PHAN_QUYEN = new HashSet<PHAN_QUYEN>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string PASS { get; set; }
        public string HOTEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public Nullable<bool> IS_SUPER_USER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAI_VIET> BAI_VIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOAT_DONG> HOAT_DONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHAN_QUYEN> PHAN_QUYEN { get; set; }
    }
}
