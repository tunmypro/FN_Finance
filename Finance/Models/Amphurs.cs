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
    
    public partial class Amphurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Amphurs()
        {
            this.Tambons = new HashSet<Tambons>();
        }
    
        public string AmpurID { get; set; }
        public string AmpurName { get; set; }
        public string AmpurProvinceID { get; set; }
    
        public virtual Provinces Provinces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tambons> Tambons { get; set; }
    }
}
