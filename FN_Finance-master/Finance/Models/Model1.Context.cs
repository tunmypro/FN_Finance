﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Finance5917Entities1 : DbContext
    {
        public Finance5917Entities1()
            : base("name=Finance5917Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<GuaranteeCustomers> GuaranteeCustomers { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<LicenseStatusDisplay> LicenseStatusDisplay { get; set; }
        public virtual DbSet<LicenseTypes> LicenseTypes { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<StatusCustomer> StatusCustomer { get; set; }
        public virtual DbSet<StatusUser> StatusUser { get; set; }
        public virtual DbSet<title> title { get; set; }
        public virtual DbSet<User_Finance> User_Finance { get; set; }
        public virtual DbSet<MoneyView> MoneyView { get; set; }
    }
}
