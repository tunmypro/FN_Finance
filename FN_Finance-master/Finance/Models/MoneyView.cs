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
    
    public partial class MoneyView
    {
        public Nullable<System.DateTime> Date_Start { get; set; }
        public Nullable<System.DateTime> Date_End { get; set; }
        public Nullable<System.DateTime> Date_Last { get; set; }
        public decimal Balance { get; set; }
        public decimal Out_Balance { get; set; }
        public decimal Per_Month_Amount { get; set; }
        public decimal Payment_Money { get; set; }
        public System.DateTime PaymentDate { get; set; }
    }
}