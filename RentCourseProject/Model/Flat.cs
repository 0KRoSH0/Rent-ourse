//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCourseProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flat()
        {
            this.Invoicing = new HashSet<Invoicing>();
            this.PaymentHistory = new HashSet<PaymentHistory>();
            this.Users = new HashSet<Users>();
        }
    
        public int IdFlat { get; set; }
        public int NumberFlat { get; set; }
        public Nullable<int> Residents { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int IdHouse { get; set; }
    
        public virtual House House { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoicing> Invoicing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
