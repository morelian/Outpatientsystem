﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Outpatientsystem.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OutpatientDemoEntities : DbContext
    {
        public OutpatientDemoEntities()
            : base("name=OutpatientDemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Booking> tb_Booking { get; set; }
        public virtual DbSet<tb_Diagnosticlist> tb_Diagnosticlist { get; set; }
        public virtual DbSet<tb_Doctor> tb_Doctor { get; set; }
        public virtual DbSet<tb_Drug> tb_Drug { get; set; }
        public virtual DbSet<tb_Keshi> tb_Keshi { get; set; }
        public virtual DbSet<tb_Pharmacy> tb_Pharmacy { get; set; }
        public virtual DbSet<tb_Pro_title> tb_Pro_title { get; set; }
        public virtual DbSet<tb_Type> tb_Type { get; set; }
        public virtual DbSet<tb_User> tb_User { get; set; }
        public virtual DbSet<tb_Worksheet> tb_Worksheet { get; set; }
        public virtual DbSet<DoctorView> DoctorView { get; set; }
        public virtual DbSet<DrugView> DrugView { get; set; }
        public virtual DbSet<UWYView> UWYView { get; set; }
        public virtual DbSet<WkView> WkView { get; set; }
        public virtual DbSet<WorksheetView> WorksheetView { get; set; }
        public virtual DbSet<WYView> WYView { get; set; }
        public virtual DbSet<YYView> YYView { get; set; }
        public virtual DbSet<ZDrugView> ZDrugView { get; set; }
        public virtual DbSet<ZDView> ZDView { get; set; }
    }
}