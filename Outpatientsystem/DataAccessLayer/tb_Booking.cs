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
    
    public partial class tb_Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Booking()
        {
            this.tb_Diagnosticlist = new HashSet<tb_Diagnosticlist>();
        }
    
        public string No { get; set; }
        public string UserNo { get; set; }
        public string WorkNo { get; set; }
        public Nullable<bool> Deal { get; set; }
    
        public virtual tb_User tb_User { get; set; }
        public virtual tb_Worksheet tb_Worksheet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Diagnosticlist> tb_Diagnosticlist { get; set; }
    }
}
