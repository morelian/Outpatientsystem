//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tb_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_User()
        {
            this.tb_Booking = new HashSet<tb_Booking>();
        }
    
        public string No { get; set; }
        public byte[] Password { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public decimal Balance { get; set; }
        public Nullable<bool> ViolationRecord { get; set; }
        public Nullable<System.DateTime> Betitled { get; set; }
        public string Addres { get; set; }
        public Nullable<int> FailCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Booking> tb_Booking { get; set; }
    }
}