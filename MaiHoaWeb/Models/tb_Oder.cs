//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaiHoaWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Oder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Oder()
        {
            this.tb_OrderDetail = new HashSet<tb_OrderDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> IsPaid { get; set; }
    
        public virtual tb_Customer tb_Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_OrderDetail> tb_OrderDetail { get; set; }
    }
}