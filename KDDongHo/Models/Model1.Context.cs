﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLKD_DONGHOEntities : DbContext
    {
        public QLKD_DONGHOEntities()
            : base("name=QLKD_DONGHOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAI_VIET> BAI_VIET { get; set; }
        public virtual DbSet<DAT_HANG> DAT_HANG { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<DONG_HO> DONG_HO { get; set; }
        public virtual DbSet<HANG_SX> HANG_SX { get; set; }
        public virtual DbSet<HINH_ANH> HINH_ANH { get; set; }
        public virtual DbSet<HOAT_DONG> HOAT_DONG { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<KIEU_MAY> KIEU_MAY { get; set; }
        public virtual DbSet<LUOT_LIKE> LUOT_LIKE { get; set; }
        public virtual DbSet<NGUOI_DUNG> NGUOI_DUNG { get; set; }
        public virtual DbSet<PHAN_QUYEN> PHAN_QUYEN { get; set; }
        public virtual DbSet<QUYEN_LOI> QUYEN_LOI { get; set; }
        public virtual DbSet<SLIDE> SLIDEs { get; set; }
    }
}
