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
    
    public partial class KHACH_HANG
    {
        public KHACH_HANG()
        {
            this.DON_HANG = new HashSet<DON_HANG>();
            this.LUOT_LIKE = new HashSet<LUOT_LIKE>();
        }
    
        public int ID { get; set; }
        public string HOTEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }
        public string EMAIL { get; set; }
        public string PASS { get; set; }
    
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }
        public virtual ICollection<LUOT_LIKE> LUOT_LIKE { get; set; }
    }
}
