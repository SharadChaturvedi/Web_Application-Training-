//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RR_System_MP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket_Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket_Booking()
        {
            this.Ticket_Cancellation = new HashSet<Ticket_Cancellation>();
        }
    
        public Nullable<decimal> Train_id { get; set; }
        public string userID { get; set; }
        public decimal Ticket_no { get; set; }
        public string Class { get; set; }
    
        public virtual Traindetail Traindetail { get; set; }
        public virtual Userdetail Userdetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_Cancellation> Ticket_Cancellation { get; set; }
    }
}