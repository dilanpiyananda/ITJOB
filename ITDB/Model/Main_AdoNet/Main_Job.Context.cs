﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITDB.Model.Main_AdoNet
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class itjob_mainEntities : DbContext
    {
        public itjob_mainEntities()
            : base("name=itjob_mainEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_company_has_job> tbl_company_has_job { get; set; }
        public virtual DbSet<tbl_document> tbl_document { get; set; }
        public virtual DbSet<tbl_job_main> tbl_job_main { get; set; }
        public virtual DbSet<tbl_trust> tbl_trust { get; set; }
        public virtual DbSet<tbl_user_company_details> tbl_user_company_details { get; set; }
        public virtual DbSet<tbl_globle_note> tbl_globle_note { get; set; }
        public virtual DbSet<tbl_company_has_accept_email> tbl_company_has_accept_email { get; set; }
    }
}