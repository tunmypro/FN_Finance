
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
    
public partial class GuaranteeCustomers : MyClass
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public GuaranteeCustomers()
    {

        this.Contracts = new HashSet<Contracts>();

    }


    public string ID_Card_g { get; set; }

    public Nullable<int> titleid { get; set; }

    public string Name_g { get; set; }

    public string Lname_g { get; set; }

    public string tel { get; set; }

    public string Address_g { get; set; }

    public string District_g { get; set; }

    public string Amphur_g { get; set; }

    public string Province_g { get; set; }

    public string Zipcode_g { get; set; }

    public string Career_g { get; set; }

    public Nullable<decimal> Salary_g { get; set; }

    public Nullable<int> Status_g { get; set; }

    public byte[] Image_g { get; set; }

    public byte[] ID_img_g { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Contracts> Contracts { get; set; }

    public virtual StatusCustomer StatusCustomer { get; set; }

    public virtual title title { get; set; }

}

}
