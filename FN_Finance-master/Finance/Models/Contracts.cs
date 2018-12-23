//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finance.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contracts: MyClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contracts()
        {
            this.Payments = new HashSet<Payments>();
        }
    
        public string ContractID { get; set; }
        public int LicenseID { get; set; }
        public string ID_Card_m { get; set; }
        public string ID_Card_g { get; set; }
        public Nullable<System.DateTime> Date_Start { get; set; }
        public Nullable<System.DateTime> Date_End { get; set; }
        public Nullable<System.DateTime> Date_Last { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Out_Balance { get; set; }
        public decimal? Per_Month_Amount { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual GuaranteeCustomers GuaranteeCustomers { get; set; }
        public virtual License License { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
